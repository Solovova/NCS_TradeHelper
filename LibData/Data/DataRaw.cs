namespace LibData.Data;

public class DataRaw{
    public string Symbol{ get; }
    public TypeDataRaw Type{ get; }

    public event EventHandler? DataChanged;

    public DataRaw(string symbol, TypeDataRaw type){
        this.Symbol = symbol;
        this.Type = type;
    }

    public void OnDataChange(){
        DataChanged?.Invoke(this, EventArgs.Empty);
    }
}