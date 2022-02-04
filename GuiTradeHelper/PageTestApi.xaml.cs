using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CryptoExchange.Net.Objects;
using SoloVova.TradeHelper.LibTradeHelper.binance.LowApi;
using Utf8Json;

namespace SoloVova.TradeHelper.GuiTradeHelper {
    public partial class PageTestApi : Page {
        public PageTestApi() {
            InitializeComponent();
        }

        private void Button_TradeHistory_OnClick(object sender, RoutedEventArgs e) {
            ApiSpot.GetTradeHistoryAsync("BTCUSDT").ContinueWith(this.OnGetResult);
        }

        private void Button_Products_OnClick(object sender, RoutedEventArgs e) {
            ApiGeneral.GetProductsAsync().ContinueWith(this.OnGetResult);
        }

        private void Button_UserCoins_OnClick(object sender, RoutedEventArgs e) {
            ApiGeneral.GetUserCoins().ContinueWith(this.OnGetResult);
        }

        private void Button_AccountInfo_OnClick(object sender, RoutedEventArgs e) {
            ApiGeneral.GetAccountInfoAsync().ContinueWith(this.OnGetResult);
        }

        private void Button_MarginAccountInfo_OnClick(object sender, RoutedEventArgs e) {
            ApiMargin.GetMarginAccountInfoAsync().ContinueWith(this.OnGetResult);
        }

        private void OnGetResult<T>(Task<WebCallResult<T>> res) {
            this.Dispatcher.Invoke(() => {
                if (res.IsCompletedSuccessfully) {
                    this.Tb.Text =
                        "Ok\n" + JsonSerializer.PrettyPrint(JsonSerializer.ToJsonString(res.Result.Data));
                } else {
                    this.Tb.Text = "Error:" + res.Exception?.Message;
                }
            });
        }
    }
}