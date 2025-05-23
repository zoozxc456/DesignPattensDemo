namespace DesignPattens.Creational.Builder;

public class MacBookPro
{
    public string Processor { get; set; }
    public string Keyboard { get; set; }
    public string Monitor { get; set; }
    public string Storage { get; set; }
    public string Memory { get; set; }

    public string SpecificationString =>
        $"Processor: {Processor}\r\n" +
        $"Keyboard: {Keyboard}\r\n" +
        $"Monitor: {Monitor}\r\n" +
        $"Storage: {Storage}\r\n" +
        $"Memory: {Memory}\r\n";
}

public abstract class MacBookProBuilder
{
    protected readonly MacBookPro MacbookPro = new();

    public abstract MacBookProBuilder BuildProcessor(string processor);
    public abstract MacBookProBuilder BuildKeyboard(string keyboard);
    public abstract MacBookProBuilder BuildMonitor(string monitor);
    public abstract MacBookProBuilder BuildStorage(string storage);
    public abstract MacBookProBuilder BuildMemory(string memory);

    public MacBookPro Build() => MacbookPro;
}

public class MacBookProM1Builder : MacBookProBuilder
{
    public override MacBookProBuilder BuildProcessor(string processor)
    {
        MacbookPro.Processor = processor;
        return this;
    }

    public override MacBookProBuilder BuildKeyboard(string keyboard)
    {
        MacbookPro.Keyboard = keyboard;
        return this;
    }

    public override MacBookProBuilder BuildMonitor(string monitor)
    {
        MacbookPro.Monitor = monitor;
        return this;
    }

    public override MacBookProBuilder BuildStorage(string storage)
    {
        MacbookPro.Storage = storage;
        return this;
    }

    public override MacBookProBuilder BuildMemory(string memory)
    {
        MacbookPro.Memory = memory;
        return this;
    }
}

public class MacBookProSeller(MacBookProBuilder builder)
{
    public MacBookPro Basic() => builder
        .BuildProcessor("2.4 GHz M1 CPU 6-Cores")
        .BuildKeyboard("Basic Keyboard")
        .BuildMonitor("Basic Monitor")
        .BuildStorage("128GB")
        .BuildMemory("16GB")
        .Build();

    public MacBookPro Advance() => builder
        .BuildProcessor("3.2 GHz M1 CPU 8-Cores")
        .BuildKeyboard("Advance Keyboard")
        .BuildMonitor("Advance Monitor")
        .BuildStorage("256GB")
        .BuildMemory("24GB")
        .Build();

    public MacBookPro Premium()=> builder
        .BuildProcessor("4.8 GHz M1 CPU 16-Cores")
        .BuildKeyboard("Premium Keyboard")
        .BuildMonitor("Premium Monitor")
        .BuildStorage("2TB")
        .BuildMemory("48GB")
        .Build();
}

public static class BuilderDemo
{
    public static void Main()
    {
        var m1Builder = new MacBookProM1Builder();

        var seller = new MacBookProSeller(m1Builder);

        var basicMacBookPro = seller.Basic();
        Console.WriteLine("Basic MacBook Pro M1");
        Console.WriteLine(basicMacBookPro.SpecificationString);

        var advanceMacBookPro = seller.Advance();
        Console.WriteLine("Advance MacBook Pro M1");
        Console.WriteLine(advanceMacBookPro.SpecificationString);

        var premiumMacBookPro = seller.Premium();
        Console.WriteLine("Premium MacBook Pro M1");
        Console.WriteLine(premiumMacBookPro.SpecificationString);
    }
}