namespace TerminalTodoApp.Logic;

public static class InputHandler
{
    private static void InputHandlerDataLoad()
    {
        TodoManager.LoadJsonData();
    }

    private static void InputHandlerDataSave()
    {
        TodoManager.SaveJsonData();
    }

    private static void InputHandlerTodoStatusUpdater()
    {
        Console.Write("What is the id of the todo you wish to update? \n");
        var todoId = InputParseToInt();
        var todo   = TodoManager.FindTodoById(todoId);
        Console.Write(
            $"Todo of ID {todo.TodoId} has the following status: {todo.IsCompleted}.\n Do you wish to change it to {!todo.IsCompleted} (y/n)?\n");
        var input = InputValidator();
        if (input.ToLowerInvariant() == "y")
            TodoManager.ToggleTodoCompletionStatus(todo);
        else
            Console.WriteLine("Ok, going back now.");
    }

    private static void InputHandlerTodoNameUpdater()
    {
        Console.Write("What is the id of the todo you wish to update?");
        var todoId = InputParseToInt();
        var todo   = TodoManager.FindTodoById(todoId);
        Console.Write("What is the new name of your todo? \n");
        var newName = InputValidator();
        TodoManager.UpdateTodoName(todo, newName);
    }

    private static void InputHandlerTodoRemover()
    {
        Console.Write("What is the id of the todo you wish removed? \n");
        var todoId = InputParseToInt();
        var todo   = TodoManager.FindTodoById(todoId);
        TodoManager.RemoveFromList(todo);
    }

    private static int InputParseToInt()
    {
        var input = InputValidator();
        Console.WriteLine(int.TryParse(input, out var todoId)
                              ? $"Todo with id {todoId}."
                              : "Invalid input. Please enter a valid integer.");
        return todoId;
    }

    private static void InputHandlerTodoCreation()
    {
        Console.Write("What is the name of your todo? \n");
        var todoName = InputValidator();
        TodoManager.CreateTodo(todoName);
    }

    private static string InputValidator()
    {
        var input = Console.ReadLine() ??
                    throw new ArgumentNullException(string.Format("Console.ReadLine('Input > '{0})", "ARG0"));
        return input;
    }

    private static void InputHandlerDisplayAllTodos()
    {
        TodoManager.DisplayAllTodos();
    }

    public static bool InputHandlerMainMenu()
    {
        var input = Console.ReadLine() ?? throw new InvalidOperationException();
        switch (input)
        {
            case "1":
                InputHandlerTodoCreation();
                break;
            case "32":
                InputHandlerTodoRemover();
                break;
            case "3":
                InputHandlerTodoNameUpdater();
                break;
            case "4":
                InputHandlerTodoStatusUpdater();
                break;
            case "5":
                InputHandlerDataSave();
                break;
            case "6":
                InputHandlerDataLoad();
                break;
            case "7":
                InputHandlerClearJsonData();
                break;
            case "8":
                InputHandlerDisplayAllTodos();
                break;
            case "-1":
                return false;
            default:
                Console.WriteLine("Invalid Input!");
                break;
        }

        return true;
    }

    private static void InputHandlerClearJsonData()
    {
        TodoManager.ClearTodoList();
    }
}