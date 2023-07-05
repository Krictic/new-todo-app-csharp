using System.Diagnostics;
using TerminalTodoApp.Display;

namespace TerminalTodoApp.Logic;

public static class InputValidationAndParsingMethods
{
    private static string ReadFromConsole()
    {
        var input = Console.ReadLine();
        Debug.Assert(input != null, nameof(input) + " != null");
        return input;
    }

    private static void ValidateInput(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input), "Empty input is not allowed");
        }
    }

    public static string GetValidatedInput()
    {
        var input = ReadFromConsole();
        ValidateInput(input);
        return input;
    }

    public static int InputParseToInt()
    {
        var input         = GetValidatedInput();
        var requestTodoId = UserPromptMethods.InputParsingPrompt(input);
        return requestTodoId;
    }
}