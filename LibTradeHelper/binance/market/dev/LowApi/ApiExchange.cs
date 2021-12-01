using System.Threading.Tasks;
using Binance.Net.Objects.Spot.MarketData;
using CryptoExchange.Net.Objects;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.market.dev.LowApi
{
    public static class ApiExchange
    {
        public static async Task<WebCallResult<BinancePrice>> GetPriceAsync(string symbol)
        {
            ContextMarket cm = ContextMarket.Instance();
            var callResult = await cm.Client.Spot.Market.GetPriceAsync(symbol);
            return callResult;
        }
    }
}