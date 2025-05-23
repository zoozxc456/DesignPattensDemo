namespace DesignPattens.Structural.Bridge;

public interface IElectronicActions
{
    void TurnOn();
    void TurnOff();
}

public abstract class Electronic(IElectronicActions actions)
{
    private IElectronicActions Actions { get; } = actions;

    public virtual void TurnOn() => Actions.TurnOn();
    public virtual void TurnOff() => Actions.TurnOff();
}

public class Television(IElectronicActions actions) : Electronic(actions)
{
}

public class Computer(IElectronicActions actions) : Electronic(actions)
{
}

public class GamingComputerActions : IElectronicActions
{
    public void TurnOn()
    {
        Console.WriteLine("Shinning RGB lights all start");
    }

    public void TurnOff()
    {
        Console.WriteLine("Shinning RGB lights all stop");
    }
}

public class IoTTelevisionActions : IElectronicActions
{
    public void TurnOn()
    {
        Console.WriteLine("Starting to connect network");
    }

    public void TurnOff()
    {
        Console.WriteLine("Disposing to connect network");
    }
}

public static class BridgeDemo
{
    public static void Main()
    {
        var television = new Television(new IoTTelevisionActions());
        var computer = new Computer(new GamingComputerActions());

        television.TurnOn();
        computer.TurnOn();

        television.TurnOff();
        computer.TurnOff();
    }
}