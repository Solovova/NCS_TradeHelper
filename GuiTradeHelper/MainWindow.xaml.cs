using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using SoloVova.TradeHelper.LibTradeHelper.binance.market.dev.UpLevel.wallet;

namespace SoloVova.TradeHelper.GuiTradeHelper{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window{
        public MainWindow(){
            InitializeComponent();
        }
        
        private void ButtonRefresh_OnClick(object sender, RoutedEventArgs e)
        {
            Wallet wallet = new Wallet();
            Task<decimal> sum = wallet.GetTotalSum();

            sum.ContinueWith(res =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.txtWallet.Content = res.Result.ToString(CultureInfo.InvariantCulture);
                });
            });

        }
    }
}