using TerminalTodoApp.Domain;

namespace TerminalTodoApp.Logic;

public static class DisplayTodoMethods
{
    public static void DisplayTodo(Todo todo)
    {
        Console.WriteLine((string?)FormatTodo(todo));
    }

    public static string FormatTodo(Todo todo)
    {
        return
            $"=========================================================\nTodo   : {todo.Name}\nId     : {todo.TodoId}\nStatus : {(todo.IsCompleted ? "Complete" : "Incomplete")}";
    }
}