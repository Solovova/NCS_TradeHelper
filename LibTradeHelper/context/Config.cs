using System;
using System.IO;
using SoloVova.TradeHelper.LibTradeHelper.context.configs;
using Utf8Json;

namespace SoloVova.TradeHelper.LibTradeHelper.context
{
    public class Config
    {
        public readonly ConfigBinance ConfigBinance;
        public readonly ConfigDb ConfigDb;

        public Config()
        {
            this.ConfigBinance = Config.LoadFromJson<ConfigBinance>("secure\\");
            this.ConfigDb = Config.LoadFromJson<ConfigDb>("secure\\");
        }
        
        public void SaveToJson()
        {
            Config.SaveToJson<ConfigBinance>(ConfigBinance,"secure\\");
            Config.SaveToJson<ConfigDb>(ConfigDb,"secure\\");
        }
        
        private static T LoadFromJson<T>(string subDir)
        {
            string fileName = Resources.GetAppRootFullName($"{subDir}{typeof(T).Name}.json");
            if (!File.Exists(fileName)) return (T)Activator.CreateInstance(typeof(T))!;
            using StreamReader file = File.OpenText(fileName);
            string str = file.ReadToEnd();
            return JsonSerializer.Deserialize<T>(str);
        }
        
        private static void SaveToJson<T>(T obj, string subDir)
        {
            string fileName = Resources.GetAppRootFullName($"{subDir}{typeof(T).Name}.json");
            using StreamWriter file = File.CreateText(fileName);
            string str = JsonSerializer.ToJsonString(obj) ?? "";
            file.Write(str);
        }
    }
}