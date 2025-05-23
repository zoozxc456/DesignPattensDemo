namespace DesignPattens.Creational.Singleton;

public class DataAccess
{
    private static DataAccess _instance;
    private static object _locker = new();

    private DataAccess()
    {
    }

    public static DataAccess GetInstance()
    {
        if (_instance == null)
        {
            lock (_locker)
            {
                if (_instance == null) _instance = new DataAccess();
            }
        }

        return _instance;
    }

    public void ShowHashCode() => Console.WriteLine(_instance.GetHashCode());
}

public static class SingletonDemo
{
    public static void Main()
    {
        for (var i = 0; i < 100; i++)
        {
            DataAccess.GetInstance().ShowHashCode();
        }
    }
}