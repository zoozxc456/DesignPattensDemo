namespace DesignPattens.Behavioral.Observer;

public interface IObservable
{
    void Add(IObserver observer);
    void Remove(IObserver observer);
    string GetName();
    void Notify();
}

public interface IObserver
{
    void Update(string message);
}

public class Youtuber(string name) : IObservable
{
    private readonly List<IObserver> _audiences = [];

    public void Add(IObserver observer) => _audiences.Add(observer);

    public void Remove(IObserver observer) => _audiences.Remove(observer);
    public string GetName() => name;

    public void Notify()
    {
        const string message = "上片囉";
        _audiences.ForEach(audience => { audience.Update(message); });
    }
}

public class Audience(IObservable observable) : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"{observable.GetName()} Send a notification, message: {message}");
    }
}

public static class ObserverDemo
{
    public static void Main()
    {
        var aGa = new Youtuber("AGa");
        for (var i = 0; i < 100; i++)
        {
            var audience = new Audience(aGa);
            aGa.Add(audience);
        }
        
        aGa.Notify();
    }
}