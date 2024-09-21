using TaskCli.Services;
using TaskCli.Services.Concrete;
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
            if (!(args.Length < 3)) taskManager.AddTask(args[1], args[2]);
            break;
        case "update":
            if (!(args.Length < 4)) taskManager.UpdateTask(Guid.Parse(args[1]), args[2], args[3]);
            break;
        case "delete":
            if (!(args.Length < 2)) taskManager.DeleteTask(Guid.Parse(args[1]));
            break;
        case "list":
            if (!(args.Length > 1)) taskManager.GetAllTask();
            break;
        case "list-by-status":
            if(!(args.Length < 2)) taskManager.GetAllTaskByStatus(args[1]);
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