using System.IO;

namespace SoloVova.TradeHelper.LibTradeHelper.context {
    public static class Resources {
        private static string _resourceDir = string.Empty;

        private static void InitResourceDir() {
            if (!string.IsNullOrEmpty(_resourceDir)) {
                return;
            }
            string dir = Directory.GetCurrentDirectory();
            while (!Directory.Exists($"{dir}\\resource\\")) {
                dir = Directory.GetParent(dir)?.FullName ?? throw new DirectoryNotFoundException("resource");
            }
            _resourceDir = $"{dir}\\resource\\";
        }

        public static string GetAppRootFullName(string shortFileName) {
            InitResourceDir();
            return _resourceDir + shortFileName;
        }
    }
}