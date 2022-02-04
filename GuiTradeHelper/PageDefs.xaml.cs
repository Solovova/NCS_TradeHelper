using SoloVova.TradeHelper.LibTradeHelper.context;
using System.Windows;
using System.Windows.Controls;

namespace SoloVova.TradeHelper.GuiTradeHelper {
    public partial class PageDefs : Page {
        public PageDefs() {
            InitializeComponent();
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e) {
            Context.Instance().Config.ConfigDefs.DefProduct = this.TbDefProduct.Text;
            Context.Instance().Config.SaveToJson();
        }

        private void PageDefs_OnLoaded(object sender, RoutedEventArgs e) {
            this.TbDefProduct.Text = Context.Instance().Config.ConfigDefs.DefProduct ?? "";
        }
    }
}