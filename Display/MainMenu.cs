using System.Text;
using TerminalTodoApp.Logic;
using TerminalTodoApp;

namespace TerminalTodoApp.Display;

public static class MainMenu
{
    public static void DisplayMainMenu()
    {
        var mainMenuStrings = StringBuilders.MainMenuBuilder();
        var keepRendering   = true;
        while (keepRendering)
        {
            Console.Clear();
            Console.WriteLine(mainMenuStrings);
            keepRendering = InputHandler.InputHandlerMainMenu();
        }
    }
}