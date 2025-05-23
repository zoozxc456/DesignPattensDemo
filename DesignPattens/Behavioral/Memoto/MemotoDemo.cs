using System.Numerics;

namespace DesignPattens.Behavioral.Memoto;

public class PaintMemoto
{
    public Vector2 StartVector { get; set; }
    public Vector2 EndVector { get; set; }
}

public class PaintOriginator
{
    private Vector2 StartVector { get; set; }
    private Vector2 EndVector { get; set; }

    public PaintMemoto Save()
    {
        return new PaintMemoto
        {
            StartVector = StartVector,
            EndVector = EndVector
        };
    }

    public void Restore(PaintMemoto memoto)
    {
        StartVector = memoto.StartVector;
        EndVector = memoto.EndVector;
    }

    public void Draw(Vector2 start, Vector2 end)
    {
        StartVector = start;
        EndVector = end;
    }

    public void DisplayCurrentVector()
    {
        Console.WriteLine(
            $"Current Start Vector:({StartVector.X},{StartVector.Y}), End Vector:({EndVector.X},{EndVector.Y})");
    }
}

public class PaintCareTaker
{
    private const int MaxBackupSize = 15;
    private readonly LinkedList<PaintMemoto> _backups = new();

    public void Add(PaintMemoto memoto)
    {
        if (_backups.Count >= MaxBackupSize)
        {
            _backups.RemoveFirst();
        }

        _backups.AddLast(memoto);
    }

    public PaintMemoto Get()
    {
        _backups.RemoveLast();
        if (_backups.Last is null) return null;
        return _backups.Last.Value;
    }
}

public class PaintFacade(PaintOriginator originator, PaintCareTaker careTaker)
{
    public void DrawWithAutoSave(Vector2 start, Vector2 end)
    {
        originator.DisplayCurrentVector();
        originator.Draw(start, end);
        careTaker.Add(originator.Save());
        originator.DisplayCurrentVector();
    }

    public void Rollback()
    {
        originator.DisplayCurrentVector();
        originator.Restore(careTaker.Get());
        originator.DisplayCurrentVector();
    }
}

public static class MemotoDemo
{
    public static void Main()
    {
        var facade = new PaintFacade(new PaintOriginator(), new PaintCareTaker());

        facade.DrawWithAutoSave(new Vector2(3, 2), new Vector2(4, 6));
        facade.DrawWithAutoSave(new Vector2(11, 7), new Vector2(5, 10));

        facade.Rollback();
    }
}