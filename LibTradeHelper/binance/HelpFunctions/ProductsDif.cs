using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoloVova.TradeHelper.LibTradeHelper.binance.LowApi;
using SoloVova.TradeHelper.LibTradeHelper.binance.UpLevel.products;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.HelpFunctions{
    public static class ProductsDif{
        public static async Task<List<string>> GetDif(Products products){
            products.LoadFromJson();
            List<string> result = new List<string>();
            await ApiGeneral.GetUserCoins().ContinueWith(res => {
                if (res.IsCompletedSuccessfully && products.BinanceUserCoin != null){
                    var dif =
                        res.Result.Data.Where(p => products.BinanceUserCoin.All(l => p.Coin != l.Coin));
                    result = dif.Select(i => i.Coin).ToList();
                    products.BinanceUserCoin = res.Result.Data;
                    products.SaveToJson();
                }
            });
            return result;
        } 
    }
}