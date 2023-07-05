using TerminalTodoApp.Display;

namespace TerminalTodoApp.Logic
{
    public static class InputHandler
    {
        private static void InputHandlerTodoCreation()
        {
            UserPromptMethods.AskTodoName();
            var todoName = InputValidationAndParsingMethods.GetValidatedInput();
            TodoManager.CreateTodo(todoName);
        }

        private static void InputHandlerTodoRemover()
        {
            Console.Write("What is the id of the todo you wish removed? \n");
            var todoId = InputValidationAndParsingMethods.InputParseToInt();
            var todo   = TodoManager.FindTodoById(todoId);
            if (todo != null)
            {
                TodoManager.RemoveFromList(todo);
            }
            else
            {
                UserPromptMethods.NoIdFoundWarning();
            }

        }

        private static void InputHandlerTodoNameUpdater()
        {
            UserPromptMethods.TodoPrompts("update");
            var todoId = InputValidationAndParsingMethods.InputParseToInt();
            var todo   = TodoManager.FindTodoById(todoId);
            UserPromptMethods.AskTodoNewName();
            var newName = InputValidationAndParsingMethods.GetValidatedInput();
            TodoManager.UpdateTodoName(todo, newName);
        }

        private static void InputHandlerTodoStatusUpdater()
        {
            UserPromptMethods.TodoPrompts("update");
            var todoId = InputValidationAndParsingMethods.InputParseToInt();
            var todo   = TodoManager.FindTodoById(todoId);
            if (todo == null)
            {
                UserPromptMethods.NoIdFoundWarning();
            }

            UserPromptMethods.AskForStatusUpdate(todo);
            var input = InputValidationAndParsingMethods.GetValidatedInput();
            if (input.ToLowerInvariant() == "y")
                TodoManager.ToggleTodoCompletionStatus(todo);
            else
                UserPromptMethods.GoBackWithoutAlterations();
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
    }
}