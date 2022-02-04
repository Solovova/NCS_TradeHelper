using SoloVova.TradeHelper.LibTradeHelper.binance.UpLevel.wallet;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SoloVova.TradeHelper.GuiTradeHelper {
    public partial class PageWallet : Page {
        public PageWallet() {
            InitializeComponent();
        }

        private void ButtonRefresh_OnClick(object sender, RoutedEventArgs e) {
            Wallet wallet = new Wallet();
            Task<decimal> sum = wallet.GetTotalSum();

            sum.ContinueWith(res => {
                this.Dispatcher.Invoke(() => {
                    this.txtWallet.Content = res.Result.ToString(CultureInfo.InvariantCulture);
                });
            });

        }
    }
}