namespace DesignPattens.Creational.AbstractFactory;

public interface ILaptop
{
    string ShowLaptopSpec();
}

public interface IPc
{
    string ShowPcSpec();
}

public class SavedBatteryLaptop : ILaptop
{
    public string ShowLaptopSpec() => "Power Switch Charge: 80%";
}

public class ExtremeLaptop : ILaptop
{
    public string ShowLaptopSpec() => "CPU Limit: 5.5 GHz";
}

public class WorkstationPc : IPc
{
    public string ShowPcSpec() => "Workstation PC";
}

public class GamerPc : IPc
{
    public string ShowPcSpec() => "Gamer PC";
}

public abstract class AbstractFactory
{
    public abstract ILaptop CreateLaptop();
    public abstract IPc CreatePc();
}

public class TaipeiFactory : AbstractFactory
{
    public override ILaptop CreateLaptop() => new SavedBatteryLaptop();

    public override IPc CreatePc() => new WorkstationPc();
}

public class TaichungFactory : AbstractFactory
{
    public override ILaptop CreateLaptop() => new ExtremeLaptop();

    public override IPc CreatePc() => new GamerPc();
}

public static class AbstractFactoryDemo
{
    public static void Main()
    {
        AbstractFactory tpAbstractFactory = new TaipeiFactory();
        AbstractFactory tchAbstractFactory = new TaichungFactory();

        var tpLaptop = tpAbstractFactory.CreateLaptop();
        var tpPc = tpAbstractFactory.CreatePc();

        var tchLaptop = tchAbstractFactory.CreateLaptop();
        var tchPc = tchAbstractFactory.CreatePc();

        foreach (var laptop in new List<ILaptop> { tpLaptop, tchLaptop })
        {
            Console.WriteLine(laptop.ShowLaptopSpec());
        }

        foreach (var pc in new List<IPc> { tpPc, tchPc })
        {
            Console.WriteLine(pc.ShowPcSpec());
        }
    }
}