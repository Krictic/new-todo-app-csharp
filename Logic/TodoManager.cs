using ConsoleApp1.Domain;

namespace ConsoleApp1.Logic;

public static class TodoManager
{
    private static List<Todo> _todoList = new();
    private static JsonHandler _jsonHandler = new();


    public static void CreateTodo(string name)
    {
        var todo = new Todo(name);
        AddToList(todo);
    }

    public static void UpdateTodoName(Todo todo, string newName)
    {
        todo.Name = newName;
    }

    public static void UpdateTodoCompletion(Todo todo)
    {
        todo.IsCompleted = todo.IsCompleted != true;
    }

    public static void AddToList(Todo todo)
    {
        if (!_todoList.Contains(todo))
            _todoList.Add(todo);
        else
            Console.WriteLine("This todo is already on the list!");
    }

    public static void RemoveFromList(Todo todo)
    {
        if (_todoList.Contains(todo))
            _todoList.Remove(todo);
        else
            Console.WriteLine("This todo is not on the list!");
    }

    public static Todo FindTodoById(int todoId)
    {
        foreach (var todo in _todoList.Where(todo => todo.TodoId == todoId)) return todo;

        throw new Exception("We could not find this ID on the list.");
    }

    public static void DisplayAllTodos()
    {
        foreach (var todo in _todoList)
        {
            DisplayTodo(todo);
        }
    }

    private static void DisplayTodo(Todo todo)
    {
        Console.WriteLine(FormatTodo(todo));
    }

    private static string FormatTodo(Todo todo)
    {
        return $"Todo: {todo.Name}\n" +
               $"Id: {todo.TodoId}\n" +
               $"Status : {(todo.IsCompleted ? "Complete" : "Incomplete")}";
    }

    public static void SaveJsonData()
    {
        JsonHandler.Save(_todoList);
    }

    public static void LoadJsonData()
    {
        _todoList = JsonHandler.Load();
    }
}