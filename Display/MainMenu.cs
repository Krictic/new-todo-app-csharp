using System.Text;
using TerminalTodoApp.Logic;

namespace TerminalTodoApp.Display;

public static class MainMenu
{
    public static void DisplayMainMenu()
    {
        var stringBuilder = new StringBuilder();
        bool keepRendering = true;
        stringBuilder.AppendLine("============= TodoApp =============")
                     .AppendLine("|| 1. Create New Todo            ||")
                     .AppendLine("|| 2. Remove Todo From TodoList  ||")
                     .AppendLine("|| 3. Update Todo Name           ||")
                     .AppendLine("|| 4. Update Todo Status         ||")
                     .AppendLine("|| 5. Save Todo Data             ||")
                     .AppendLine("|| 6. Load Todo Data             ||")
                     .AppendLine("|| 7. Clear Todo Data            ||")
                     .AppendLine("|| 8. Display Todo List          ||")
                     .AppendLine("|| -1. Exit                      ||");
        while (keepRendering)
        {
            Console.WriteLine(stringBuilder);
            keepRendering = InputHandler.InputHandlerMainMenu();
        }
    }
}