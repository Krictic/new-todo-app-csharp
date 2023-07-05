using System.Diagnostics;
using TerminalTodoApp.Display;
using TerminalTodoApp;

namespace TerminalTodoApp.Logic;

public static class InputHandler
{
    private static void InputHandlerTodoCreation()
    {
        UserPromptMethods.AskTodoName();
        var todoName = InputValidationAndParsingMethods.GetValidatedStringInput();
        UserPromptMethods.AskForPriority();
        var todoPriority = InputValidationAndParsingMethods.InputParseToInt();
        TodoManager.CreateTodo(todoName, todoPriority);
    }

    private static void InputHandlerTodoRemover()
    {
        UserPromptMethods.TodoPrompts("remove");
        var todoId = InputValidationAndParsingMethods.InputParseToInt();
        var todo   = TodoManager.FindTodoById(todoId);
        if (todo != null)
            TodoManager.RemoveFromList(todo);
        else
            UserPromptMethods.NoIdFoundWarning();
    }

    private static void InputHandlerTodoNameUpdater()
    {
        UserPromptMethods.TodoPrompts("update");
        var todoId = InputValidationAndParsingMethods.InputParseToInt();
        var todo   = TodoManager.FindTodoById(todoId);
        UserPromptMethods.AskTodoNewName();
        var newName = InputValidationAndParsingMethods.GetValidatedStringInput();
        TodoManager.UpdateTodoName(todo, newName);
    }

    private static void InputHandlerTodoStatusUpdater()
    {
        UserPromptMethods.TodoPrompts("update");
        var todoId = InputValidationAndParsingMethods.InputParseToInt();
        var todo   = TodoManager.FindTodoById(todoId);
        if (todo == null) UserPromptMethods.NoIdFoundWarning();

        Debug.Assert(todo != null, nameof(todo) + " != null");
        UserPromptMethods.AskForStatusUpdate(todo);
        var input = InputValidationAndParsingMethods.GetValidatedStringInput();
        if (input?.ToLowerInvariant() == "y")
            TodoManager.ToggleTodoCompletionStatus(todo);
        else
            UserPromptMethods.GoBackWithoutAlterations();
    }

    private static void InputHandlerUpdatePriority()
    {
        UserPromptMethods.TodoPrompts("change priority number");
        var todoId = InputValidationAndParsingMethods.InputParseToInt();
        var todo   = TodoManager.FindTodoById(todoId);
        if (todo == null) UserPromptMethods.NoIdFoundWarning();

        Debug.Assert(todo != null, nameof(todo) + " != null");
        UserPromptMethods.AskForPriorityUpdate(todo);
        var newPriority = InputValidationAndParsingMethods.InputParseToInt();
        TodoManager.UpdateTodoPriority(todo, newPriority);
    }

    private static void InputHandlerDataSave()
    {
        TodoManager.SaveJsonData();
    }

    private static void InputHandlerDataLoad()
    {
        TodoManager.LoadJsonData();
    }

    private static void InputHandlerClearJsonData()
    {
        TodoManager.ClearTodoList();
    }

    private static void InputHandlerDisplayAllTodos()
    {
        TodoManager.DisplayAllTodos();
    }

    public static bool InputHandlerMainMenu()
    {
        UserPromptMethods.MainMenuPrompting();
        var input = Console.ReadLine() ?? throw new InvalidOperationException();
        switch (input)
        {
            case "1":
                InputHandlerTodoCreation();
                break;
            case "2":
                InputHandlerTodoRemover();
                break;
            case "3":
                InputHandlerTodoNameUpdater();
                break;
            case "4":
                InputHandlerTodoStatusUpdater();
                break;
            case "5":
                InputHandlerUpdatePriority();
                break;
            case "6":
                InputHandlerDataSave();
                break;
            case "7":
                InputHandlerDataLoad();
                break;
            case "8":
                InputHandlerClearJsonData();
                break;
            case "9":
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
}