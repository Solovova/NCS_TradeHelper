using LibData.Data;

var dc = new DataCollection();

var dcBtc = dc.GetData("BTCUSDT",TypeDataRaw.M5);
dcBtc.DataChanged += Listener1;
dcBtc.OnDataChange();

var dcEth = dc.GetData("ETHUSDT",TypeDataRaw.M5);
dcEth.DataChanged += Listener2;
dcEth.OnDataChange();

var str = Console.ReadLine();

static async void Listener1(object? sender, EventArgs e){
    var dataRaw = sender as DataRaw ?? throw new ArgumentNullException(nameof(sender), "Listener1");
    if (e is not EventDataRawArgs args) throw new ArgumentException($"Listener1 Must be type: ${typeof(EventDataRawArgs)}",nameof(e));
    await Task.Delay(1000);
    Console.WriteLine($"DataChange {dataRaw.Symbol} {dataRaw.Type} {args.Somedata}");
}

static void Listener2(object? sender, EventArgs e){
    var dataRaw = sender as DataRaw ?? throw new ArgumentNullException(nameof(sender), "Listener2");
    if (e is not EventDataRawArgs args) throw new ArgumentException($"Listener2 Must be type: ${typeof(EventDataRawArgs)}",nameof(e));
    Console.WriteLine($"DataChange {dataRaw.Symbol} {dataRaw.Type} {args.Somedata}");
}
