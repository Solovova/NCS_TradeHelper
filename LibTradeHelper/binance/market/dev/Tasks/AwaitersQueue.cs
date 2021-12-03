﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoloVova.TradeHelper.LibTradeHelper.binance.market.dev.Tasks.Awaiters;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.market.dev.Tasks
{
    public class AwaitersQueue
    {
        private readonly List<IAwaiter> _awaiters = new List<IAwaiter>();
        
        public void Add(IAwaiter awaiter)
        {
            this._awaiters.Add(awaiter);
        }

        public void Run()
        {
            foreach (IAwaiter awaiter in this._awaiters)
            {
                if (awaiter.Status is EnAwaiterStatus.DontSend or EnAwaiterStatus.Error)
                {
                    awaiter.Run();
                }
            }
        }

        public bool Complete()
        {
            return this._awaiters.All(awaiter => awaiter.Status == EnAwaiterStatus.Ok);
        }

        public async Task Join()
        {
            while (!this.Complete())
            {
                await Task.Delay(50);
            }
        }
    }
}