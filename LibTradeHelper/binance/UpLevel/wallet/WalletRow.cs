using Binance.Net.Objects.Spot.MarginData;
using Binance.Net.Objects.Spot.SpotData;

namespace SoloVova.TradeHelper.LibTradeHelper.binance.UpLevel.wallet {
    public class WalletRow {
        private string _symbol = "";

        public string Symbol {
            get => _symbol;
        }

        private WalletTypeEn _type;

        public WalletTypeEn Type {
            get => _type;
        }

        private decimal _free;

        public decimal Free {
            get => _free;
        }

        private decimal _total;

        public decimal Total {
            get => _total;
        }

        private decimal _locked;

        public decimal Locked {
            get => _locked;
        }

        private decimal _borrowed;

        public decimal Borrowed {
            get => _borrowed;
        }

        private decimal _price;

        public decimal Price {
            get => _price;
            set { _price = value; }
        }

        public decimal Sum {
            get => _total * _price;
        }

        public static WalletRow Instance(BinanceMarginBalance row) {
            return new WalletRow() {
                _symbol = row.Asset,
                _type = WalletTypeEn.Margin,
                _free = row.Free,
                _locked = row.Locked,
                _total = row.Total,
                _borrowed = row.Borrowed + row.Interest
            };
        }

        public static WalletRow Instance(BinanceBalance row) {
            return new WalletRow() {
                _symbol = row.Asset,
                _type = WalletTypeEn.Spot,
                _free = row.Free,
                _locked = row.Locked,
                _total = row.Total
            };
        }
    }
}