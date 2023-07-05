namespace TerminalTodoApp.Domain;

public class Todo
{
    private static int _todoCount;

    public Todo(string name)
    {
        Name        = name;
        IsCompleted = false;
        TodoId      = _todoCount;
        _todoCount++;
    }

    public string Name        { get; set; }
    public int    TodoId      { get; set; }
    public bool   IsCompleted { get; set; }
}