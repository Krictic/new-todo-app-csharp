﻿using TerminalTodoApp.Display;
using TerminalTodoApp.Domain;

namespace TerminalTodoApp.Logic;

public static class TodoManager
{
    private static List<Todo> _todoList = new();

    public static void CreateTodo(string name)
    {
        var todo = new Todo(name);
        AddToList(todo);
    }

    public static void UpdateTodoName(Todo? todo, string newName)
    {
        todo.Name = newName;
    }

    public static void ToggleTodoCompletionStatus(Todo? todo)
    {
        todo.IsCompleted = !todo.IsCompleted;
    }

    public static void AddToList(Todo todo)
    {
        if (!_todoList.Contains(todo))
            _todoList.Add(todo);
        else
            Console.WriteLine("This todo is already on the list!");
    }

    public static void RemoveFromList(Todo todo)
    {
        if (_todoList.Contains(todo))
            _todoList.Remove(todo);
        else
            Console.WriteLine("This todo is not on the list!");
    }

    public static Todo? FindTodoById(int todoId)
    {
        return _todoList.SingleOrDefault(todo => todo.TodoId == todoId);
    }

    public static void DisplayAllTodos()
    {
        if (_todoList.Count != 0)
        {
            foreach (var todo in _todoList)
            {
                DisplayTodoMethods.DisplayTodo(todo);
                Console.ReadKey();
            }
        }
        else
        {
            UserPromptMethods.EmptyListWarning();
        }
        
    }

    public static void SaveJsonData()
    {
        JsonHandler.Save(_todoList);
    }

    public static void LoadJsonData()
    {
        _todoList = JsonHandler.Load();
        Console.WriteLine("Saved Todo Data successfully loaded.\n" +
                          "Press any button to continue...");
        Console.ReadKey();
    }

    public static void ClearTodoList()
    {
        _todoList.Clear();
        JsonHandler.ClearJsonData();
    }
}