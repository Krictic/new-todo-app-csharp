using Newtonsoft.Json;
using TerminalTodoApp.Domain;

namespace TerminalTodoApp.Logic;

public static class JsonHandler
{
    private static readonly string JsonPath = "./Data/TodoData.json";

    public static void VerifyJsonData()
    {
        if (File.Exists(JsonPath))
        {
            var jsonData = File.ReadAllText(JsonPath);

            ValidateJsonData(jsonData);
        }
        else
        {
            CreateJsonFile();
        }
    }

    private static void ValidateJsonData(string jsonData)
    {
        if (jsonData.Trim() != "{}")
        {
            Console.WriteLine("Existing Todo Data found.\n");
            Console.WriteLine("Press any key to load Todo Data.");
            Console.ReadKey();
            TodoManager.LoadJsonData();
        }
        else
        {
            Console.WriteLine("Empty JSON object found, skipping load.\n" +
                              "Press any key to continue.");
        }
    }

    private static void CreateJsonFile()
    {
        var dir = Path.GetDirectoryName(JsonPath);
        if (!Directory.Exists(dir))
            if (dir != null)
                Directory.CreateDirectory(dir);
        File.WriteAllText(JsonPath, "[]");
    }

    public static void Save(List<Todo> todoList)
    {
        using var file       = File.CreateText(JsonPath);
        var       serializer = new JsonSerializer();
        serializer.Serialize(file, todoList);
    }

    public static List<Todo> Load()
    {
        using var file       = File.OpenText(JsonPath);
        var       serializer = new JsonSerializer();
        var       todos      = (List<Todo>)serializer.Deserialize(file, typeof(List<Todo>))!;
        return todos;
    }

    public static void ClearJsonData()
    {
        File.WriteAllText(JsonPath, "{}");
    }
}