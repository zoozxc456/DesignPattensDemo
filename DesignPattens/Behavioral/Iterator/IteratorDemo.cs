namespace DesignPattens.Behavioral.Iterator;

public interface IIterator<out T>
{
    public T? First();
    public T? Next();
    public T? Current();
    public bool IsDone();
}

public interface IAggregate<out T> where T : class
{
    public IIterator<T> CreateIterator();
}

public abstract class Organization(string name)
{
    public string Name => name;
    public abstract void AddOrganization(Organization? organization);
}

public class Company(string name) : Organization(name), IAggregate<Organization>
{
    public readonly List<Organization?> Divisions = [];

    public override void AddOrganization(Organization? organization)
    {
        Divisions.Add(organization);
    }

    public IIterator<Organization> CreateIterator()
    {
        return new CompanyIterator(this);
    }
}

public class Division(string name) : Organization(name)
{
    public override void AddOrganization(Organization? organization)
    {
    }
}

public class CompanyIterator(Company company) : IIterator<Organization>
{
    private int _currentIndex;

    public Organization? First()
    {
        return company.Divisions[0];
    }

    public Organization? Next()
    {
        return ++_currentIndex < company.Divisions.Count ? company.Divisions[_currentIndex] : null;
    }

    public Organization? Current()
    {
        return _currentIndex < company.Divisions.Count ? company.Divisions[_currentIndex] : null;
    }

    public bool IsDone()
    {
        return Current() == null;
    }
}

public static class IteratorDemo
{
    public static void Main()
    {
        var apdv = new Division("APDV");
        var tbdv = new Division("TBDV");
        var rmdv = new Division("RMDV");

        var company = new Company("Titansoft");
        company.AddOrganization(apdv);
        company.AddOrganization(tbdv);
        company.AddOrganization(rmdv);

        var iterator = company.CreateIterator();

        while (!iterator.IsDone())
        {
            Console.WriteLine(iterator.Current()?.Name);
            iterator.Next();
        }
    }
}