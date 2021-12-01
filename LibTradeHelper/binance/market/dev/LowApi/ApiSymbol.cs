using System.Collections.Generic;
using System.Threading.Tasks;
using Binance.Net.Interfaces;
using CryptoExchange.Net.Objects;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.market.dev.LowApi{
    public static class ApiSymbol{
        public static async Task<WebCallResult<IEnumerable<IBinanceRecentTrade>>> GetTradeHistory(string symbol)
        {
            ContextMarket cm = ContextMarket.Instance();
            var callResult = await cm.Client.Spot.Market.GetTradeHistoryAsync(symbol);
            return callResult;
        }
    }
}