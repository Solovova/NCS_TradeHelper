namespace SoloVova.TradeHelper.LibTradeHelper.binance.Tasks.Awaiters {
    public interface IAwaiter {
        public EnAwaiterStatus Status { get; }
        public void Run();
    }
}