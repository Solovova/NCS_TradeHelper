using Binance.Net.Objects.Spot.MarginData;
using CryptoExchange.Net.Objects;
using System.Threading.Tasks;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.LowApi {
    public static class ApiMargin {
        public static async Task<WebCallResult<BinanceMarginAccount>> GetMarginAccountInfoAsync() {
            return await ContextMarket.Instance().Client.Margin.GetMarginAccountInfoAsync();
        }
    }
}