using SoloVova.TradeHelper.LibTradeHelper.binance.HelpFunctions;
using SoloVova.TradeHelper.LibTradeHelper.binance.UpLevel.products;
using System.Windows;
using System.Windows.Controls;

namespace SoloVova.TradeHelper.GuiTradeHelper {
    public partial class PageCoins : Page {
        private readonly Products _products;

        public PageCoins() {
            InitializeComponent();
            _products = new Products();
        }

        private void Button_Refresh_OnClick(object sender, RoutedEventArgs e) {
            _products.Refresh(true).ContinueWith(res => {
                string allCoins = "";
                if (res.Result.BinanceUserCoin != null) {
                    foreach (var bc in res.Result.BinanceUserCoin) {
                        allCoins += bc.Coin + "\n";
                    }
                }

                this.Dispatcher.Invoke(() => { this.Tb.Text = allCoins; });
            });
        }

        private void Button_Dif_OnClick(object sender, RoutedEventArgs e) {
            ProductsDif.GetDif(_products).ContinueWith(res => {
                string allCoins = "Ok\n" + string.Concat(res.Result);
                this.Dispatcher.Invoke(() => { this.Tb.Text = allCoins; });
            });
        }
    }
}