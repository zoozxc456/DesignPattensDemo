namespace DesignPattens.Behavioral.Mediator;

public interface INetworkMediator
{
    void AddDevice(IDevice device);
    void Broadcast(IDevice sender, string message);
}

public interface IDevice
{
    string GetAddress();
    void Send(string message);
    void Receive(string message);
}

public class StarNetworkRouter : INetworkMediator
{
    private readonly List<IDevice> _devices = [];

    public void AddDevice(IDevice device) => _devices.Add(device);

    public void Broadcast(IDevice sender, string message)
    {
        var toBeSentMessage = $"Sender: {sender.GetAddress()} sent a message: {message}";
        _devices.ForEach(device =>
        {
            if (!device.GetAddress().Equals(sender.GetAddress()))
                device.Receive(toBeSentMessage);
        });
    }
}

public class TerminalDevice(string address, INetworkMediator mediator) : IDevice
{
    public string GetAddress() => address;

    public void Send(string message)
    {
        mediator.Broadcast(this, message);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"Receiver:{address}, {message}");
    }
}

public static class MediatorDemo
{
    public static void Main()
    {
        var router = new StarNetworkRouter();

        var device1 = new TerminalDevice("192.168.0.2", router);
        var device2 = new TerminalDevice("192.168.0.3", router);
        var device3 = new TerminalDevice("192.168.0.4", router);
        var device4 = new TerminalDevice("192.168.0.5", router);

        router.AddDevice(device1);
        router.AddDevice(device2);
        router.AddDevice(device3);
        router.AddDevice(device4);

        device1.Send("hello1");
        device2.Send("hello2");
        device3.Send("hello3");
        device4.Send("hello4");
    }
}