using System.Diagnostics;
using System.Text;
using TerminalTodoApp.Domain;
using TerminalTodoApp.Logic;

namespace TerminalTodoApp.Display;

public static class UserPromptMethods
{
    public static void TodoPrompts(string todoOperation)
    {
        Console.Write($"What is the id of the todo you wish to {todoOperation}? \n");
    }

    public static void NoIdFoundWarning()
    {
        Console.WriteLine("There is no such object on the list, returning.\n" +
                          "Press any key to confirm.");
        Console.ReadKey();
    }

    public static void EmptyListWarning()
    {
        Console.WriteLine("The TodoList is empty.\n" +
                          "Press any key to continue...");
        Console.ReadKey();
    }

    public static void AskTodoName()
    {
        Console.Write("What is the name of your todo? \n");
    }

    public static void AskTodoNewName()
    {
        Console.Write("What is the new name of your todo? \n");
    }

    public static int InputParsingPrompt(string? input)
    {
        Console.WriteLine(int.TryParse(input, out var requestTodoId)
                              ? $"Todo with id {requestTodoId}."
                              : "Invalid input. Please enter a valid integer.");
        return requestTodoId;
    }

    public static void AskForStatusUpdate(Todo todo)
    {
        Debug.Assert(todo != null, nameof(todo) + " != null");
        Console.Write(
            $"Todo of ID {todo.TodoId} has the following status: {todo.IsCompleted}.\n Do you wish to change it to {!todo.IsCompleted} (y/n)? ");
    }

    public static void GoBackWithoutAlterations()
    {
        Console.Write("Ok, we are not changing anything then.\n" +
                          "Press any key to go back...");
        Console.ReadKey();
    }

    public static void MainMenuPrompting()
    {
        Console.Write("Select a valid menu option by its number\n" +
                      "Input > ");
    }

    public static void AskForPriority()
    {
        Console.WriteLine("Input a number form 0 to 5, to define the Todo Priority number. See Below for definitions.");
        Console.WriteLine(value: StringBuilders.PriorityDefinitions());
    }

    public static void NullInputWarning()
    {
        
        Console.WriteLine("Warning: Input cannot be null.\n" +
                          "Press any key to confirm");
        Console.ReadKey();
    }

    public static void AskForPriorityUpdate(Todo todo)
    {
        Console.WriteLine($"The current priority for this Todo is {todo.TodoPriority} - {DisplayTodoMethods.TodoPriorityInterpretation(todo)}\n" +
                          $"To which priority number you wish it changed to?\n" +
                          $"{StringBuilders.PriorityDefinitions()}");
    }

    public static void DisplayNewPriority(Todo todo)
    {
        Console.WriteLine($"The Priority number of {todo.Name} is now {todo.TodoPriority} - {DisplayTodoMethods.TodoPriorityInterpretation(todo)}\n" +
                          $"Press any key to confirm...");
        Console.ReadKey();
    }
}