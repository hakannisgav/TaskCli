using System.Runtime.InteropServices;
using System.Text.Json;
using Task = TaskCli.Models.Task;

namespace TaskCli.Services.Concrete;

public class TaskService : ITaskService
{
    private const string FileName = "tasks.json";
    private readonly List<Task> _tasks;

    public TaskService(List<Task> tasks)
    {
        _tasks = LoadTasks();
    }

    //Add new Tasks in Json File.
    public void AddTask(string description, string status = "to-do")
    {
        try
        {
            var newTask = new Task(description, status)
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Status = status.ToLower(),
                UpdatedAt = null
            };
            _tasks.Add(newTask);
            SaveTasks();
            Console.WriteLine($"Task added successfully (ID: {newTask.Id})");
        }
        catch
        {
            Console.WriteLine($"Task can not added. Check Information Please!");
            throw;
        }
    }

    //Updated Task Description by TaskID
    public void UpdateTask(Guid id, string newDescription, string status)
    {
        try
        {
            var task = _tasks.FirstOrDefault(x => x.Id == id);
            task.Description = newDescription;
            task.Status = status.ToLower();
            task.UpdatedAt = DateTime.Now;
            SaveTasks();
            Console.WriteLine("Task updated successfully.");
        }
        catch
        {
            Console.WriteLine($"Task with ID {id} not found.");
            throw;
        }
    }

    //Delete Task by TaskID
    public void DeleteTask(Guid id)
    {
        try
        {
            var task = _tasks.FirstOrDefault(x => x.Id == id);
            _tasks.Remove(task);
            SaveTasks();
            Console.WriteLine($"Task deleted successfully.");
        }
        catch
        {
            Console.WriteLine($"Task with ID {id} not found.");
            throw;
        }
    }

    //In the following cases, it loads the tasks from the JSON File. If there is no file, it creates a new list from scratch.
    public void GetAllTask()
    {
        try
        {
            var json = File.ReadAllText(FileName);
            var tasks = JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }
        catch
        {
            Console.WriteLine($"File Not Found.");
            throw;
        }
    }

    //Get tasks by status value.
    public void GetAllTaskByStatus(string status)
    {
        try
        {
            var json = File.ReadAllText(FileName);
            var tasks = JsonSerializer.Deserialize<List<Task>>(json)?.FindAll(x => x.Status == status).ToList() ??
                        new List<Task>();
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }
        catch
        {
            Console.WriteLine("File not found or you dont have any tasks this status.");
            throw;
        }
    }

    //Write last tasks to file.
    public void SaveTasks()
    {
        var json = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FileName, json);
    }
    
    //LoadTasks for App
    private List<Task> LoadTasks()
    {
        try
        {
            if (File.Exists(FileName))
            {
                var json = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
            }
        }
        catch
        {
            Console.WriteLine("Error reading the task file.");
        }
        return new List<Task>();
    }
}