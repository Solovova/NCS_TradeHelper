namespace LibData.Data;

public class DataCollection{
    private readonly Dictionary<string, DataCollectionsSymbol> _dataCollection = new();

    public DataRaw GetData(string symbol, TypeDataRaw type){
        if (!_dataCollection.ContainsKey(symbol)){
            _dataCollection[symbol] = new DataCollectionsSymbol(symbol);
        }

        return _dataCollection[symbol].GetData(type);
    }
}