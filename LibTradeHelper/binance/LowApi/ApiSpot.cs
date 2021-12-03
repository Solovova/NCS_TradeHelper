using System.Collections.Generic;
using System.Threading.Tasks;
using Binance.Net.Interfaces;
using Binance.Net.Objects.Spot.MarketData;
using CryptoExchange.Net.Objects;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.LowApi{
    public static class ApiSpot{
        public static async Task<WebCallResult<IEnumerable<IBinanceRecentTrade>>> GetTradeHistoryAsync(string symbol){
            return await ContextMarket.Instance().Client.Spot.Market.GetTradeHistoryAsync(symbol);
        }

        public static async Task<WebCallResult<BinancePrice>> GetPriceAsync(string symbol){
            return await ContextMarket.Instance().Client.Spot.Market.GetPriceAsync(symbol);
        }
    }
}