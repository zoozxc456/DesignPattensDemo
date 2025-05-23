namespace DesignPattens.Behavioral.ChainOfResponsibility;

interface IHandler
{
    IHandler SetNext(IHandler handler);
    object Handle(object request);
}

abstract class AbstractHandler : IHandler
{
    private IHandler _nextHandler;

    public IHandler SetNext(IHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual object Handle(object request)
    {
        return _nextHandler != null ? _nextHandler.Handle(request) : null;
    }
}

class DepartmentManager : AbstractHandler
{
    public override object Handle(object request)
    {
        if (request.ToString() == "Department")
        {
            return $"DM Handle {request.ToString()} Event";
        }

        return base.Handle(request);
    }
}

class Director : AbstractHandler
{
    public override object Handle(object request)
    {
        if (request.ToString() == "Division")
        {
            return $"Director Handle {request.ToString()} Event";
        }

        return base.Handle(request);
    }
}

class GeneralManager : AbstractHandler
{
    public override object Handle(object request)
    {
        if (request.ToString() == "Company")
        {
            return $"GM Handle {request.ToString()} Event";
        }

        return base.Handle(request);
    }
}

class TeamLeader : AbstractHandler
{
    public override object Handle(object request)
    {
        if (request.ToString() == "Team")
        {
            return $"Team Leader Handle {request.ToString()} Event";
        }

        return base.Handle(request);
    }
}

class Employee : AbstractHandler
{
}

public static class ChainOfResponsibilityDemo
{
    public static void Main()
    {
        var employee = new Employee();
        employee.SetNext(new TeamLeader())
            .SetNext(new DepartmentManager())
            .SetNext(new Director())
            .SetNext(new GeneralManager());

        var result = employee.Handle("Team");

        if (result == null) Console.WriteLine("No one catch this event");
        else Console.WriteLine(result);
    }
}