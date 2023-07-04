using System.Text;
using ConsoleApp1.Logic;

namespace ConsoleApp1.Display;

public static class MainMenu
{
    public static void DisplayMainMenu()
    {
        var stringBuilder = new StringBuilder();
        while (true)
        {
            stringBuilder.AppendLine("============= TodoApp =============")
                .AppendLine("|| 1. Create New Todo            ||")
                .AppendLine("|| 2. Remove Todo From TodoList  ||")
                .AppendLine("|| 3. Update Todo Name           ||")
                .AppendLine("|| 4. Update Todo Status         ||")
                .AppendLine("|| 5. Save Todo Data             ||")
                .AppendLine("|| 6. Load Todo Data             ||")
                .AppendLine("|| 7. Display Todo List          ||")
                .AppendLine("|| -1. Exit                      ||");

            Console.WriteLine(stringBuilder);

            InputHandler.InputHandlerMainMenu();
        }
        // ReSharper disable once FunctionNeverReturns
    }
}