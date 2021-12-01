using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Binance.Net.Interfaces;
using CryptoExchange.Net.Objects;
using SoloVova.TradeHelper.LibTradeHelper.binance.market.dev.LowApi;
using Utf8Json;

namespace SoloVova.TradeHelper.GuiTradeHelper{
    public partial class WindowTestTrade : Window{
        public WindowTestTrade(){
            InitializeComponent();
        }
        
        private void ButtonRefresh_OnClick(object sender, RoutedEventArgs e)
        {
            Task<WebCallResult<IEnumerable<IBinanceRecentTrade>>> task = ApiSymbol.GetTradeHistory("BTCUSDT");
            task.ContinueWith(res =>
            {
                this.Dispatcher.Invoke(() => {
                    if (res.IsCompletedSuccessfully){
                        this.tb.Text = "Ok\n"+JsonSerializer.ToJsonString(res.Result.Data);    
                    }
                    else{
                        this.tb.Text = "Error:" + res.Exception?.Message;
                    }
                    
                });
            });

        }
    }
}