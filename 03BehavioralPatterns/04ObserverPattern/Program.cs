Console.WriteLine("Observer Pattern...");

var station = new WeaterStation();

var phone = new PhoneDisplay("iphone");
var tv = new TvDisplay("samsung");

station.Subscribe(phone);
station.Subscribe(tv);

station.SetMeasurements(30);
station.SetMeasurements(15);
station.SetMeasurements(25);

Console.ReadLine();

interface IWeaterStation
{
    void Subscribe(IObserver observer);
    void UnSubscribe(IObserver observer);
    decimal GetTemp();
    void Notify();
}

class WeaterStation : IWeaterStation
{
    private readonly List<IObserver> _observers = new();
    private decimal _tempature;
    public void SetMeasurements(decimal temp)
    {
        _tempature = temp;
        Console.WriteLine("[Station] new measurement: Temp {0}", temp);
        Notify();
        Console.WriteLine("------");
    }

    public decimal GetTemp() => _tempature;
    public void Subscribe(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void UnSubscribe(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }
}

interface IObserver
{
    void Update(IWeaterStation station);
}

class PhoneDisplay : IObserver
{
    private string _name;

    public PhoneDisplay(string name)
    {
        _name = name;
    }

    public void Update(IWeaterStation station)
    {
        var temp = station.GetTemp();
        Console.WriteLine("[Phone] {0} => Temp: {1}", _name, temp);
    }
}

class TvDisplay : IObserver
{
    private string _name;

    public TvDisplay(string name)
    {
        _name = name;
    }

    public void Update(IWeaterStation station)
    {
        var temp = station.GetTemp();
        Console.WriteLine("[Tv] {0} => Temp: {1}", _name, temp);
    }
}