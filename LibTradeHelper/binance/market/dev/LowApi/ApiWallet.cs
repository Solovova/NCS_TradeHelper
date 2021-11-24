using System.Collections.Generic;
using System.Threading.Tasks;
using Binance.Net.Objects.Spot.MarginData;
using Binance.Net.Objects.Spot.SpotData;
using Binance.Net.Objects.Spot.WalletData;
using CryptoExchange.Net.Objects;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.market.dev.LowApi
{
    public static class ApiWallet
    {
        public static async Task<WebCallResult<BinanceAccountInfo>> GetAccountInfoAsync()
        {
            ContextMarket cm = ContextMarket.Instance();
            var callResult = await cm.Client.General.GetAccountInfoAsync();
            return callResult;
        }
        
        public static async Task<WebCallResult<IEnumerable<BinanceUserCoin>>> GetUserCoinsAsync()
        {
            ContextMarket cm = ContextMarket.Instance();
            var callResult = await cm.Client.General.GetUserCoinsAsync();
            return callResult;
        }
        
        public static async Task<WebCallResult<BinanceMarginAccount>> GetMarginAccountInfoAsync()
        {
            ContextMarket cm = ContextMarket.Instance();
            var callResult = await cm.Client.Margin.GetMarginAccountInfoAsync();
            return callResult;
        }
    }
}