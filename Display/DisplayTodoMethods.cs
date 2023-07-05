using TerminalTodoApp.Domain;

namespace TerminalTodoApp.Logic;

public static class DisplayTodoMethods
{
    public static void DisplayTodo(Todo todo)
    {
        Console.WriteLine((string?)FormatTodo(todo));
    }

    private static string FormatTodo(Todo todo)
    {
        return
            $"=========================================================\nTodo   : {todo.Name}\nId     : {todo.TodoId}\nStatus : {(todo.IsCompleted ? "Complete" : "Incomplete")}\nTodo Priority     : {todo.TodoPriority} - {DisplayTodoMethods.TodoPriorityInterpretation(todo)})";
    }

    private static string TodoPriorityInterpretation(Todo todo)
    {
        switch (todo.TodoPriority)
        {
            case 0:
                return "Most Urgent (Immediate action required)";
            case 1:
                return "High Priority (Action required soon)";
            case 2:
                return "Medium Priority (Needs attention)";
            case 3:
                return "Low Priority (Can be deferred)";
            case 4:
                return "Least Urgent (Completely optional)";
            case 5:
                return "No Urgency (Indefinitely optional)";
            default:
                return "Could not interpret this priority number (See if you can update it)";
        }
    }
}