using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Binance.Net.Objects.Spot.WalletData;
using CryptoExchange.Net.Objects;
using SoloVova.TradeHelper.LibTradeHelper.binance.market.dev.LowApi;
using SoloVova.TradeHelper.LibTradeHelper.context;
using Utf8Json;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.market.dev.UpLevel.products{
    public class Products{
        private IEnumerable<BinanceUserCoin>? _binanceUserCoin;

        public void Refresh(){
            ApiGeneral.GetUserCoins().ContinueWith(this.OnGetUserCoin);
        }

        private void OnGetUserCoin(Task<WebCallResult<IEnumerable<BinanceUserCoin>>> res){
            if (res.IsCompletedSuccessfully){
                this._binanceUserCoin = res.Result.Data;
                this.SaveToJson();
            }
        }

        private void SaveToJson(){
            string fileName = Resources.GetAppRootFullName("cache\\binanceUserCoin.json");
            using StreamWriter file = File.CreateText(fileName);
            string str = JsonSerializer.ToJsonString(_binanceUserCoin) ?? "";
            file.Write(str);
        }
    }
}