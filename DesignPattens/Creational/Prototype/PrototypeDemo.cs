namespace DesignPattens.Creational.Prototype;

public class Laptop
{
    public string Processor { get; set; }
    public string Keyboard { get; set; }
    public string Monitor { get; set; }
    public string Storage { get; set; }
    public string Memory { get; set; }
    public Laptop ShallowClone() => (Laptop)MemberwiseClone();
}

public static class PrototypeDemo
{
    public static void Main()
    {
        var laptop = new Laptop
        {
            Processor = "Basic Processor",
            Keyboard = "Basic Keyboard",
            Monitor = "Basic Monitor",
            Storage = "Basic Storage",
            Memory = "Basic Memory"
        };

        var cloner = laptop.ShallowClone();
        Console.WriteLine(cloner.Processor);
    }
}