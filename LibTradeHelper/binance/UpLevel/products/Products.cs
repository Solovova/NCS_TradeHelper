using Binance.Net.Objects.Spot.WalletData;
using CryptoExchange.Net.Objects;
using SoloVova.TradeHelper.LibTradeHelper.binance.LowApi;
using SoloVova.TradeHelper.LibTradeHelper.context;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Utf8Json;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.UpLevel.products {
    public class Products {
        public IEnumerable<BinanceUserCoin>? BinanceUserCoin;

        public async Task<Products> Refresh(bool useCache) {
            if (useCache) {
                this.LoadFromJson();
            } else {
                await ApiGeneral.GetUserCoins().ContinueWith(this.OnGetUserCoin);
            }

            return this;
        }

        private void OnGetUserCoin(Task<WebCallResult<IEnumerable<BinanceUserCoin>>> res) {
            if (res.IsCompletedSuccessfully) {
                this.BinanceUserCoin = res.Result.Data;
                this.SaveToJson();
            }
        }

        public void SaveToJson() {
            string fileName = Resources.GetAppRootFullName("cache\\binanceUserCoin.json");
            using StreamWriter file = File.CreateText(fileName);
            string str = JsonSerializer.ToJsonString(BinanceUserCoin) ?? "";
            file.Write(str);
        }

        public void LoadFromJson() {
            string fileName = Resources.GetAppRootFullName("cache\\binanceUserCoin.json");
            if (!File.Exists(fileName)) return;
            using StreamReader file = File.OpenText(fileName);
            string str = file.ReadToEnd();
            BinanceUserCoin = JsonSerializer.Deserialize<IEnumerable<BinanceUserCoin>>(str);
        }
    }
}