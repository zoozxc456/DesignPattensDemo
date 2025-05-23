namespace DesignPattens.Behavioral.State;

interface IEmployeeState
{
    void Promote();
    void Leave();
    void Claim();
}

public class InServiceEmployee : IEmployeeState
{
    public void Promote()
    {
        Console.WriteLine("You can promote");
    }

    public void Leave()
    {
        Console.WriteLine("You can take a leave");
    }

    public void Claim()
    {
        Console.WriteLine("You can claim expends");
    }
}

public class LeaveWithoutPayEmployee : IEmployeeState
{
    public void Promote()
    {
        Console.WriteLine("You can't promote");
    }

    public void Leave()
    {
        Console.WriteLine("You have been leaving");
    }

    public void Claim()
    {
        Console.WriteLine("You can't claim expends");
    }
}

public class InGapEmployee : IEmployeeState
{
    public void Promote()
    {
        Console.WriteLine("You can't promote because you are in gap");
    }

    public void Leave()
    {
        Console.WriteLine("You can take a leave");
    }

    public void Claim()
    {
        Console.WriteLine("You can only claim 50% expends because you are in gap");
    }
}

class EmployeeService(IEmployeeState employee)
{
    public void DoAllActions()
    {
        employee.Promote();
        employee.Leave();
        employee.Claim();
    }
}

public static class StateDemo
{
    public static void Main()
    {
        new EmployeeService(new InServiceEmployee()).DoAllActions();
        new EmployeeService(new LeaveWithoutPayEmployee()).DoAllActions();
        new EmployeeService(new InGapEmployee()).DoAllActions();
    }
}