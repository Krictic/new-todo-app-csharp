using System.Diagnostics;
using TerminalTodoApp.Display;
using TerminalTodoApp.Domain;

namespace TerminalTodoApp.Logic;

public static class TodoManager
{
    private static List<Todo> _todoList = new();

    public static void CreateTodo(string todoName, int todoPriority = 0)
    {
        var todo = new Todo(todoName, todoPriority);
        AddToList(todo);
    }

    public static void UpdateTodoName(Todo? todo, string newName)
    {
        Debug.Assert(todo != null, nameof(todo) + " != null");
        todo.Name = newName;
    }

    public static void ToggleTodoCompletionStatus(Todo? todo)
    {
        Debug.Assert(todo != null, nameof(todo) + " != null");
        todo.IsCompleted = !todo.IsCompleted;
    }

    private static void AddToList(Todo todo)
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

    public static Todo? FindTodoById(int todoId)
    {
        return _todoList.SingleOrDefault(todo => todo.TodoId == todoId);
    }

    public static void DisplayAllTodos()
    {
        if (_todoList.Count != 0)
        {
            foreach (var todo in _todoList)
            {
                DisplayTodoMethods.DisplayTodo(todo);
                Console.ReadKey();
            }
        }
        else
        {
            UserPromptMethods.EmptyListWarning();
        }
        
    }

    public static void SaveJsonData()
    {
        JsonHandler.Save(_todoList);
    }

    public static void LoadJsonData()
    {
        _todoList = JsonHandler.Load();
        Console.WriteLine("Saved Todo Data successfully loaded.\n" +
                          "Press any button to continue...");
        Console.ReadKey();
    }

    public static void ClearTodoList()
    {
        _todoList.Clear();
        JsonHandler.ClearJsonData();
    }
}