namespace LibData.Data;

public class DataCollectionsSymbol{
    private readonly Dictionary<TypeDataRaw, DataRaw> _dataCollectionsSymbol = new();
    public string Symbol{ get; }

    public DataCollectionsSymbol(string symbol){
        this.Symbol = symbol;
    }

    public DataRaw GetData(TypeDataRaw type){
        if (!_dataCollectionsSymbol.ContainsKey(type)){
            _dataCollectionsSymbol[type] = new DataRaw(Symbol, type);
        }

        return _dataCollectionsSymbol[type];
    }
}