using System.Collections.Generic;
using System.Threading.Tasks;
using Binance.Net.Objects.Other;
using Binance.Net.Objects.Spot.SpotData;
using Binance.Net.Objects.Spot.WalletData;
using CryptoExchange.Net.Objects;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.LowApi {
    public static class ApiGeneral {
        public static async Task<WebCallResult<BinanceAccountInfo>> GetAccountInfoAsync() {
            return await ContextMarket.Instance().Client.General.GetAccountInfoAsync();
        }

        public static async Task<WebCallResult<IEnumerable<BinanceProduct>>> GetProductsAsync() {
            return await ContextMarket.Instance().Client.General.GetProductsAsync();
        }

        public static async Task<WebCallResult<IEnumerable<BinanceUserCoin>>> GetUserCoins() {
            return await ContextMarket.Instance().Client.General.GetUserCoinsAsync();
        }
    }
}