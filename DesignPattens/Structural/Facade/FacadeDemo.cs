namespace DesignPattens.Structural.Facade;

public class Cpu
{
    public void Freeze() => Console.WriteLine("CPU is freezing.");
    public void Read(string obj) => Console.WriteLine($"CPU is reading from {obj}");
    public void Write(string obj) => Console.WriteLine($"CPU is writing to {obj}.");
}

public class Hdd
{
    public void Read() => Console.WriteLine("HDD is reading.");
    public void Write() => Console.WriteLine("HDD is writing.");
}

public class Memory
{
    public void Load() => Console.WriteLine("Memory is loading.");
    public void Write() => Console.WriteLine("Memory is writing.");
}

public class ComputeFacade
{
    private readonly Cpu _cpu = new();
    private readonly Hdd _hdd = new();
    private readonly Memory _memory = new();

    public void Start()
    {
        Console.WriteLine("Computer is starting...");
        _cpu.Freeze();
        _cpu.Read("HDD");
        _hdd.Read();
        _cpu.Write("Memory");
        _memory.Write();
        _cpu.Read("Memory");
        _memory.Load();
        _cpu.Write("HDD");
        _hdd.Write();
        Console.WriteLine("Computer is started already...");
    }
}

public static class FacadeDemo
{
    public static void Main()
    {
        new ComputeFacade().Start();
    }
}