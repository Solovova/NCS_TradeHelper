using System;
using System.Threading.Tasks;
using CryptoExchange.Net.Objects;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.market.dev.Tasks.Awaiters
{
    public class GetAwaiter<TOPar, TIPar0, TIPar1>: IAwaiter
    {
        private readonly Action<TOPar> _callback;
        private readonly Operation _call;
        private EnAwaiterStatus _status;
        private readonly TIPar0 _par0;
        private readonly TIPar1 _par1;

        public delegate Task<WebCallResult<TOPar>> Operation(TIPar0 par0, TIPar1 par1);


        public EnAwaiterStatus Status => _status;

        public GetAwaiter(Action<TOPar> callback, Operation call, TIPar0 par0, TIPar1 par1)
        {
            this._callback = callback;
            this._call = call;
            this._par0 = par0;
            this._par1 = par1;
            this._status = EnAwaiterStatus.DontSend;
        }

        public async void Run()
        {
            this._status = EnAwaiterStatus.Waiting;

            WebCallResult<TOPar> task = await this._call(_par0, _par1);

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