using System.Windows;
using System.Windows.Controls;
using SoloVova.TradeHelper.LibTradeHelper.binance.market.dev.UpLevel.products;

namespace SoloVova.TradeHelper.GuiTradeHelper{
    public partial class PageCoins : Page{
        private readonly Products _products;
        
        public PageCoins(){
            InitializeComponent();

            _products = new Products();
        }
        
        private void Button_Refresh_OnClick(object sender, RoutedEventArgs e){
            _products.Refresh();
        }
    }
}