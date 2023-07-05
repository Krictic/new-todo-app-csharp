﻿using TerminalTodoApp.Domain;

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

    public static int InputParsingPrompt(string input)
    {
        Console.WriteLine(int.TryParse(input, out var requestTodoId)
                              ? $"Todo with id {requestTodoId}."
                              : "Invalid input. Please enter a valid integer.");
        return requestTodoId;
    }

    public static void AskForStatusUpdate(Todo? todo)
    {
        Console.Write(
            $"Todo of ID {todo.TodoId} has the following status: {todo.IsCompleted}.\n Do you wish to change it to {!todo.IsCompleted} (y/n)?\n");
    }

    public static void GoBackWithoutAlterations()
    {
        Console.WriteLine("Ok, we are not changing anything then.\n" +
                          "Press any key to go back...");
        Console.ReadKey();
    }
}