using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using SoloVova.TradeHelper.LibTradeHelper.binance.UpLevel.wallet;
using SoloVova.TradeHelper.LibTradeHelper.context;

namespace SoloVova.TradeHelper.ConsTradeHelper{
    class Program{
        static void Main(string[] args){
            // Console.WriteLine($"   ApiKey: {Context.Instance().Config.ConfigBinance.ApiKey}");
            // Console.WriteLine($"SecretKey: {Context.Instance().Config.ConfigBinance.SecretKey}");
            //
            // Wallet wallet = new Wallet();
            // Task<decimal> sum = wallet.GetTotalSum();
            //
            // Console.WriteLine($"     Sum: {sum.GetAwaiter().GetResult()}");
            List<string> res = new List<string>(){"1","2"};
            Console.WriteLine(res.Aggregate((a, b) => a + "\n" + b));
        }
    }
}