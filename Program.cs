using TerminalTodoApp.Display;
using TerminalTodoApp.Logic;
using TerminalTodoApp.Domain;

namespace TerminalTodoApp;

internal static class Program
{
    public static void Main(string[] args)
    {
        JsonHandler.VerifyJsonData();
        MainMenu.DisplayMainMenu();
    }
}