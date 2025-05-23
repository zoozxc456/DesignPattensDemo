using System.Xml.Serialization;
using System.Text.Json;

namespace DesignPattens.Structural.Adapter;

public sealed class Person
{
    public required string Name { get; init; }
    public required int Age { get; init; }
}

public interface IObjectSerializer
{
    string Serialize(object data);
}

public class JsonSerializerAdapter : IObjectSerializer
{
    public string Serialize(object data) => JsonSerializer.Serialize(data);
}

public class XmlSerializerAdapter : IObjectSerializer
{
    public string Serialize(object data)
    {
        var serializer = new XmlSerializer(data.GetType());
        using var writer = new StringWriter();
        serializer.Serialize(writer, data);
        return writer.ToString();
    }
}

public static class AdapterDemo
{
    public static void Main()
    {
        var obj = new Person { Name = "Henry", Age = 30 };

        IObjectSerializer xmlAdapter = new XmlSerializerAdapter();
        Console.WriteLine(xmlAdapter.Serialize(obj));

        IObjectSerializer jsonAdapter = new JsonSerializerAdapter();
        Console.WriteLine(jsonAdapter.Serialize(obj));
    }
}