namespace DesignPattens.Structural.Composite;

public abstract class Component(string name)
{
    protected string Name { get; } = name;
    public abstract void AddOrganization(Component organization);
    public abstract void Receive(string commander);
    public abstract void Command(string commander);
}

public class Corporation(string name) : Component(name)
{
    private readonly List<Component> _divisions = [];

    public override void AddOrganization(Component organization)
    {
        _divisions.Add(organization);
    }

    public override void Receive(string commander)
    {
    }

    public override void Command(string commander)
    {
        Console.WriteLine($"{Name} command {commander}");

        foreach (var division in _divisions)
        {
            division.Receive(commander);
        }
    }
}

public class Division(string name) : Component(name)
{
    private readonly List<Component> _departments = [];

    public override void AddOrganization(Component organization)
    {
        _departments.Add(organization);
    }

    public override void Receive(string commander)
    {
        Console.WriteLine($"{Name} receive {commander}");

        foreach (var department in _departments)
        {
            department.Receive(commander);
        }
    }

    public override void Command(string commander)
    {
        Console.WriteLine($"{Name} command {commander}");

        foreach (var department in _departments)
        {
            department.Receive(commander);
        }
    }
}

public class Department(string name) : Component(name)
{
    private readonly List<Component> _teams = [];

    public override void AddOrganization(Component organization)
    {
        _teams.Add(organization);
    }

    public override void Receive(string commander)
    {
        Console.WriteLine($"{Name} receive {commander}");

        foreach (var team in _teams)
        {
            team.Receive(commander);
        }
    }

    public override void Command(string commander)
    {
        Console.WriteLine($"{Name} command {commander}");

        foreach (var team in _teams)
        {
            team.Receive(commander);
        }
    }
}

public class Team(string name) : Component(name)
{
    public override void AddOrganization(Component organization)
    {
    }

    public override void Receive(string commander)
    {
        Console.WriteLine($"{Name} receive {commander}");
    }

    public override void Command(string commander)
    {
    }
}

public static class CompositeDemo
{
    public static void Main()
    {
        var corporation = new Corporation("Happy Corporation");

        var b2BDivision = new Division("B2B Division");
        corporation.AddOrganization(b2BDivision);

        var twDepartment = new Department("TW DP");
        var sgDepartment = new Department("SG DP");
        b2BDivision.AddOrganization(twDepartment);
        b2BDivision.AddOrganization(sgDepartment);

        twDepartment.AddOrganization(new Team("Horoyoi"));
        twDepartment.AddOrganization(new Team("Hibiki"));
        sgDepartment.AddOrganization(new Team("Arqu"));
        sgDepartment.AddOrganization(new Team("Phoenix"));

        corporation.Command("Over work to support");
        twDepartment.Command("TW DP Go to eat dinner");
        sgDepartment.Command("SG DP Go to drink");
    }
}