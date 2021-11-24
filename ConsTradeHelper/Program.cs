using System;
using SoloVova.TradeHelper.LibTradeHelper.context;

namespace SoloVova.TradeHelper.ConsTradeHelper{
    class Program{
        static void Main(string[] args){
            Console.WriteLine($"   ApiKey: {Context.Instance().Config.ConfigBinance.ApiKey}");
            Console.WriteLine($"SecretKey: {Context.Instance().Config.ConfigBinance.SecretKey}");
            
        }
    }
}