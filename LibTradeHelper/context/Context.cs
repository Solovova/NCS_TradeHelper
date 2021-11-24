namespace SoloVova.TradeHelper.LibTradeHelper.context
{
    public class Context{
        private static Context? _instance;
        private static readonly object LockObject = new();

        public Config Config;

        private Context()
        {
            this.Config = new Config();
        }

        public static Context Instance(){
            lock (LockObject){
                _instance ??= new Context();
            }
            return _instance;
        }
    }
}