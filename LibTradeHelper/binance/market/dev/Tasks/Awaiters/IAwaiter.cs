namespace SoloVova.TradeHelper.LibTradeHelper.binance.market.dev.Tasks.Awaiters
{
    public interface IAwaiter
    {
        public EnAwaiterStatus Status { get; }
        public  void Run();
    }
}