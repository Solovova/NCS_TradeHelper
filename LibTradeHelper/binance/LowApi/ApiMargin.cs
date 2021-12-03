using System.Threading.Tasks;
using Binance.Net.Objects.Spot.MarginData;
using CryptoExchange.Net.Objects;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.LowApi{
    public static class ApiMargin{
        public static async Task<WebCallResult<BinanceMarginAccount>> GetMarginAccountInfoAsync(){
            return await ContextMarket.Instance().Client.Margin.GetMarginAccountInfoAsync();
        }
    }
}