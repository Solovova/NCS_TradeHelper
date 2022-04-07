using LibData.Data;

var dc = new DataCollection();

var dcBtc = dc.GetData("BTCUSDT",TypeDataRaw.M5);
dcBtc.DataChanged += Listener1;
dcBtc.OnDataChange();

var dcEth = dc.GetData("ETHUSDT",TypeDataRaw.M5);
dcEth.DataChanged += Listener2;
dcEth.OnDataChange();

var str = Console.ReadLine();

static async void Listener1(object sender, EventArgs e){
    var dataRaw = sender as DataRaw;
    await Task.Delay(1000);
    Console.WriteLine($"DataChange {dataRaw?.Symbol} {dataRaw?.Type}");
    
}

static void Listener2(object sender, EventArgs e){
    var dataRaw = sender as DataRaw;
    Console.WriteLine($"DataChange {dataRaw?.Symbol} {dataRaw?.Type}");
    //Environment.Exit(0);
}
