using System;
using Binance.Net;
using Binance.Net.Objects;
using CryptoExchange.Net.Authentication;
using SoloVova.TradeHelper.LibTradeHelper.context;

namespace SoloVova.TradeHelper.LibTradeHelper.binance {
    public class ContextMarket {
        private static ContextMarket? _instance;
        private static readonly object LockObject = new();

        private readonly BinanceClient _client;

        public BinanceClient Client {
            get => _client;
        }

        private ContextMarket() {
            Context context = Context.Instance();
            if (context.Config.ConfigBinance.ApiKey == null || context.Config.ConfigBinance.SecretKey == null) {
                throw new ArgumentException("Keys null");
            }

            this._client = new BinanceClient(new BinanceClientOptions() {
                ApiCredentials = new ApiCredentials(
                    context.Config.ConfigBinance.ApiKey,
                    context.Config.ConfigBinance.SecretKey
                )
            });
        }

        public static ContextMarket Instance() {
            lock (LockObject) {
                _instance ??= new ContextMarket();
            }

            return _instance;
        }
    }
}