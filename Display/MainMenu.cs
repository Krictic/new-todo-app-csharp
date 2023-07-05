using System.Text;
using TerminalTodoApp.Logic;

namespace TerminalTodoApp.Display;

public static class MainMenu
{
    public static void DisplayMainMenu()
    {
        StringBuilder mainMenuStrings = StringBuilders.MainMenuBuilder();
        var keepRendering = true;
        while (keepRendering)
        {
            Console.Clear();
            Console.WriteLine(mainMenuStrings);
            keepRendering = InputHandler.InputHandlerMainMenu();
        }
    }
}