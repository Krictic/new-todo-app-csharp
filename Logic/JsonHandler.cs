using ConsoleApp1.Domain;
using Newtonsoft.Json;

namespace ConsoleApp1.Logic;

public class JsonHandler
{
    private static readonly string JsonPath = "./Data/TodoData.json";

    public JsonHandler()
    {
        VerifyJsonData();
    }

    private static void VerifyJsonData()
    {
        if (!File.Exists(JsonPath))
        {
            var dir = Path.GetDirectoryName(JsonPath);
            if (!Directory.Exists(dir))
                if (dir != null)
                    Directory.CreateDirectory(dir);
            File.WriteAllText(JsonPath, "[]");
        }
    }

    public static void Save(List<Todo> todoList)
    {
        using var file = File.CreateText(JsonPath);
        var serializer = new JsonSerializer();
        serializer.Serialize(file, todoList);
    }

    public static List<Todo> Load()
    {
        using var file = File.OpenText(JsonPath);
        var serializer = new JsonSerializer();
        var todos = (List<Todo>)serializer.Deserialize(file, typeof(List<Todo>));
        return todos;
    }
}