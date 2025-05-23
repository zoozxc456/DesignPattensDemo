namespace DesignPattens.Creational.Factory;

internal enum EmployeeType
{
    Manager,
    Sales,
    CommonEmployee
}

internal interface IEmployee
{
    void SayHi();
}

internal class Manager : IEmployee
{
    private const string Title = "Management";
    private const string EmployeeId = "E0003";

    public void SayHi()
    {
        Console.WriteLine("I'm a Manager");
        Console.WriteLine($"Title: {Title}, EmployeeId: {EmployeeId}");
    }
}

internal class Sales : IEmployee
{
    private const string Title = "Sales";
    private const string EmployeeId = "E0010";

    public void SayHi()
    {
        Console.WriteLine("I'm a Sales");
        Console.WriteLine($"Title: {Title}, EmployeeId: {EmployeeId}");
    }
}

internal class CommonEmployee : IEmployee
{
    private const string Title = "CommonEmployee";
    private const string EmployeeId = "E0030";

    public void SayHi()
    {
        Console.WriteLine("I'm a CommonEmployee");
        Console.WriteLine($"Title: {Title}, EmployeeId: {EmployeeId}");
    }
}

internal class Factory
{
    public IEmployee GetEmployee(EmployeeType type)
    {
        return type switch
        {
            EmployeeType.Manager => new Manager(),
            EmployeeType.Sales => new Sales(),
            EmployeeType.CommonEmployee => new CommonEmployee(),
            _ => new CommonEmployee()
        };
    }
}

public static class FactoryDemo
{
    public static void Main()
    {
        var factory = new Factory();

        var manager = factory.GetEmployee(EmployeeType.Manager);
        manager.SayHi();

        var sales = factory.GetEmployee(EmployeeType.Sales);
        sales.SayHi();

        var commonEmployee = factory.GetEmployee(EmployeeType.CommonEmployee);
        commonEmployee.SayHi();
    }
}