using System.Text;

namespace TerminalTodoApp.Display;

public static class StringBuilders
{
    public static string PriorityDefinitions()
    {
        var sb = new StringBuilder();

        sb.AppendLine("0 - Most Urgent (Immediate action required)");
        sb.AppendLine("1 - High Priority (Action required soon)");
        sb.AppendLine("2 - Medium Priority (Needs attention)");
        sb.AppendLine("3 - Low Priority (Can be deferred)");
        sb.AppendLine("4 - Least Urgent (Completely optional)");
        sb.AppendLine("5 - No Urgency (Indefinitely optional)");

        return sb.ToString();
    }

    public static StringBuilder MainMenuBuilder()
    {
        var sb = new StringBuilder();
        sb.AppendLine("============= TodoApp =============")
                     .AppendLine("|| 1. Create New Todo            ||")
                     .AppendLine("|| 2. Remove Todo From TodoList  ||")
                     .AppendLine("|| 3. Update Todo Name           ||")
                     .AppendLine("|| 4. Update Todo Status         ||")
                     .AppendLine("|| 5. Save Todo Data             ||")
                     .AppendLine("|| 6. Load Todo Data             ||")
                     .AppendLine("|| 7. Clear Todo Data            ||")
                     .AppendLine("|| 8. Display Todo List          ||")
                     .AppendLine("|| -1. Exit                      ||");

        return sb;
    }
}