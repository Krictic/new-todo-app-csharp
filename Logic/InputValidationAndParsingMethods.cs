using System.Diagnostics;
using TerminalTodoApp.Display;
using TerminalTodoApp;

namespace TerminalTodoApp.Logic;

public static class InputValidationAndParsingMethods
{
    private static string? ReadAndValidateFromConsole()
    {
        var input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            return input;
        }
        else
        {
            UserPromptMethods.NullInputWarning();
            return null;
        }
    }

    public static string? GetValidatedStringInput()
    {
        var input = ReadAndValidateFromConsole();
        return input;
    }

    public static int InputParseToInt()
    {
        var input         = GetValidatedStringInput();
        var requestTodoId = UserPromptMethods.InputParsingPrompt(input);
        return requestTodoId;
    }
}