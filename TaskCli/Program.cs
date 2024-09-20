using TaskCli.Services;
using Task = TaskCli.Models.Task;

var tasks = new List<Task>();
var taskManager = new TaskService(tasks);

static void ShowUsage()
{
    Console.WriteLine("Usage:");
    Console.WriteLine(" task-cli add \"Task description\"");
    Console.WriteLine(" task-cli update <id, description, status> \"New description and new status\"");
    Console.WriteLine(" task-cli delete <id>");
    Console.WriteLine(" task-cli list");
    Console.WriteLine(" task-cli list-by-status <status> \"Get By Status\"");
}

if (args.Length == 0)
{
    ShowUsage();
    return;
}

try
{
    var command = args[0].ToLower();

    switch (command)
    {
        case "add":
            if (!(args.Length < 2)) taskManager.AddTask(args[1]);
            break;
        case "update":
            if (!(args.Length < 4)) taskManager.UpdateTask(Guid.Parse(args[1]), args[2], args[3]);
            break;
        case "delete":
            if (!(args.Length < 2)) taskManager.DeleteTask(Guid.Parse(args[1]));
            break;
        case "list":
            taskManager.GetAllTask();
            break;
        case "list-by-status":
            string status = args.Length > 1 ? args[1].ToLower() : null;
            taskManager.GetAllTaskByStatus(status);
            break;
        default:
            ShowUsage();
            break;
    }
}
catch(Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    ShowUsage();
}