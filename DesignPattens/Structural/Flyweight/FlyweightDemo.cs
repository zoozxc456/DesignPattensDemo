namespace DesignPattens.Structural.Flyweight;

public enum ShapeType
{
    Circle,
    Rectangle
}

public abstract class Shape
{
    public abstract ShapeType GetShapeType();
}

public class Circle : Shape
{
    private const ShapeType Type = ShapeType.Circle;
    public override ShapeType GetShapeType() => Type;
}

public class Rectangle : Shape
{
    private const ShapeType Type = ShapeType.Rectangle;
    public override ShapeType GetShapeType() => Type;
}

public class ShapeFactory
{
    private readonly Dictionary<ShapeType, Shape> _shapes = new();

    public Shape GetShape(ShapeType type)
    {
        if (!_shapes.ContainsKey(type))
        {
            Shape shape = type switch
            {
                ShapeType.Circle => new Circle(),
                ShapeType.Rectangle => new Rectangle(),
                _ => new Circle()
            };

            _shapes.Add(type, shape);
        }

        return _shapes[type];
    }
}

public static class FlyweightDemo
{
    public static void Main()
    {
        var factory = new ShapeFactory();

        var circle1 = factory.GetShape(ShapeType.Circle);
        var circle2 = factory.GetShape(ShapeType.Circle);
        var rectangle = factory.GetShape(ShapeType.Rectangle);

        Console.WriteLine(circle1.GetShapeType().ToString());
        Console.WriteLine(rectangle.GetShapeType().ToString());

        Console.WriteLine(circle1.Equals(circle2));
    }
}