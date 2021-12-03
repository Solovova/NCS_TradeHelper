using System;
using System.Threading.Tasks;
using CryptoExchange.Net.Objects;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.Tasks.Awaiters
{
    public class GetAwaiter<T>: IAwaiter
    {
        private readonly Action<T> _callback;
        private readonly Operation _call;
        private EnAwaiterStatus _status;

        public delegate Task<WebCallResult<T>> Operation();


        public EnAwaiterStatus Status => _status;

        public GetAwaiter(Action<T> callback, Operation call)
        {
            this._callback = callback;
            this._call = call;
            this._status = EnAwaiterStatus.DontSend;
        }

        public async void Run()
        {
            this._status = EnAwaiterStatus.Waiting;

            WebCallResult<T> task = await this._call();

            if (task.Success)
            {
                this._status = EnAwaiterStatus.Ok;
                this._callback(task.Data);
            }
            else
            {
                this._status = EnAwaiterStatus.Error;
            }
        }
    }
}