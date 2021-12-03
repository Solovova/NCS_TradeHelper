using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binance.Net.Objects.Spot.MarginData;
using Binance.Net.Objects.Spot.MarketData;
using Binance.Net.Objects.Spot.SpotData;
using SoloVova.TradeHelper.LibTradeHelper.binance.LowApi;
using SoloVova.TradeHelper.LibTradeHelper.binance.Tasks;
using SoloVova.TradeHelper.LibTradeHelper.binance.Tasks.Awaiters;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.UpLevel.wallet{
    public class Wallet{
        private readonly List<WalletRow> _rows = new List<WalletRow>();
        private const string BaseSymbol = "USDT";
        private static readonly object LockObject = new();

        private void CallBackMargin(BinanceMarginAccount data){
            IEnumerable<BinanceMarginBalance> fBalances =
                data.Balances.Where(b => b.Free != 0 || b.Locked != 0 || b.Total != 0 || b.Borrowed != 0);
            lock (LockObject){
                this._rows.RemoveAll(el => el.Type == WalletTypeEn.Margin);
                foreach (var balance in fBalances){
                    this._rows.Add(WalletRow.Instance(balance));
                }
            }
        }

        private void CallBackSpot(BinanceAccountInfo data){
            IEnumerable<BinanceBalance> fBalances =
                data.Balances.Where(b => b.Free != 0 || b.Locked != 0 || b.Total != 0);
            lock (LockObject){
                this._rows.RemoveAll(el => el.Type == WalletTypeEn.Spot);
                foreach (var balance in fBalances){
                    this._rows.Add(WalletRow.Instance(balance));
                }
            }
        }

        private void CallBackPrice(BinancePrice data){
            lock (LockObject){
                foreach (var row in _rows){
                    if (data.Symbol.StartsWith(row.Symbol)){
                        row.Price = data.Price;
                    }
                }
            }
        }

        public async Task Refresh(){
            AwaitersQueue awaitersWallets = new();
            awaitersWallets.Add(
                new GetAwaiter<BinanceMarginAccount>(this.CallBackMargin, ApiMargin.GetMarginAccountInfoAsync));
            awaitersWallets.Add(new GetAwaiter<BinanceAccountInfo>(this.CallBackSpot, ApiGeneral.GetAccountInfoAsync));

            awaitersWallets.Run();
            await awaitersWallets.Join();
            List<string> symbols = new List<string>();
            lock (LockObject){
                foreach (var row in this._rows){
                    Console.WriteLine(row.Symbol);
                    if (!symbols.Contains(row.Symbol)){
                        if (row.Symbol == BaseSymbol){
                            row.Price = 1;
                        }
                        else{
                            symbols.Add(row.Symbol + BaseSymbol);
                        }
                    }
                }
            }


            AwaitersQueue awaitersPrices = new();
            foreach (string symbol in symbols){
                awaitersPrices.Add(
                    new GetAwaiter<BinancePrice, string>(this.CallBackPrice, ApiSpot.GetPriceAsync, symbol));
            }

            awaitersPrices.Run();
            await awaitersPrices.Join();
        }

        public async Task<decimal> GetTotalSum(){
            await this.Refresh();
            decimal sum = 0;
            lock (LockObject){
                sum += this._rows.Sum(row => (row.Total - row.Borrowed) * row.Price);
            }

            return sum;
        }

        public void ToConsole(){
            decimal sum = 0;
            lock (LockObject){
                foreach (var row in this._rows){
                    sum += (row.Total - row.Borrowed) * row.Price;
                    Console.WriteLine(
                        $"Type:{row.Type} Asset:{row.Symbol} Free:{row.Free} Locked:{row.Locked} Total:{row.Total} Borrowed:{row.Borrowed} Price:{row.Price}");
                }

                Console.WriteLine(
                    $"Total sum:{sum:F1}");
            }
        }
    }
}