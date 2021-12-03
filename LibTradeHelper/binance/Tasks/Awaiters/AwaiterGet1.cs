using System;
using System.Threading.Tasks;
using CryptoExchange.Net.Objects;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.Tasks.Awaiters
{
    public class GetAwaiter<TOPar, TIPar0>: IAwaiter
    {
        private readonly Action<TOPar> _callback;
        private readonly Operation _call;
        private EnAwaiterStatus _status;
        private readonly TIPar0 _par0;

        public delegate Task<WebCallResult<TOPar>> Operation(TIPar0 par);


        public EnAwaiterStatus Status => _status;

        public GetAwaiter(Action<TOPar> callback, Operation call, TIPar0 par0)
        {
            this._callback = callback;
            this._call = call;
            this._par0 = par0;
            this._status = EnAwaiterStatus.DontSend;
        }

        public async void Run()
        {
            this._status = EnAwaiterStatus.Waiting;

            WebCallResult<TOPar> task = await this._call(_par0);

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