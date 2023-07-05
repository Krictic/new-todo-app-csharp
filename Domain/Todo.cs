namespace TerminalTodoApp.Domain;

public class Todo
{
    public static int _todoCount;

    public Todo(string? name, int todoPriority)
    {
        Name         = name;
        IsCompleted  = false;
        TodoPriority = todoPriority;
        TodoId       = _todoCount;
        _todoCount++;
    }

    public string? Name         { get; set; }
    public int    TodoId       { get; set; }
    public bool   IsCompleted  { get; set; }
    public int    TodoPriority { get; set; }
}