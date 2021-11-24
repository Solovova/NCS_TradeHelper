using System;
using System.Globalization;
using System.Threading.Tasks;
using SoloVova.TradeHelper.LibTradeHelper.binance.market.dev.UpLevel.wallet;
using SoloVova.TradeHelper.LibTradeHelper.context;

namespace SoloVova.TradeHelper.ConsTradeHelper{
    class Program{
        static void Main(string[] args){
            Console.WriteLine($"   ApiKey: {Context.Instance().Config.ConfigBinance.ApiKey}");
            Console.WriteLine($"SecretKey: {Context.Instance().Config.ConfigBinance.SecretKey}");
            
            Wallet wallet = new Wallet();
            Task<decimal> sum = wallet.GetTotalSum();
            
            Console.WriteLine($"     Sum: {sum.GetAwaiter().GetResult()}");
            
            
        }
    }
}