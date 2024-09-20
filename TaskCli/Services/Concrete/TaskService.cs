using System.Text.Json;
using Task = TaskCli.Models.Task;

namespace TaskCli.Services;

public class TaskService : ITaskService
{
    private const string FileName = "tasks.json";
    private readonly List<Task> _tasks;

    public TaskService(List<Task> tasks)
    {
        _tasks = tasks;
    }

    //Add new Tasks in Json File.
    public void AddTask(string description)
    {
        try
        {
            var newTask = new Task(description)
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Status = "To-do",
                UpdatedAt = null
            };
            _tasks.Add(newTask);
            SaveTasks();
            Console.WriteLine($"Task added successfully (ID: {newTask.Id}");
        }
        catch (Exception e)
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
            task.Status = status;
            task.UpdatedAt = DateTime.Now;
            SaveTasks();
            Console.WriteLine("Task updated successfully.");
        }
        catch (Exception e)
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
        catch (Exception e)
        {
            Console.WriteLine($"Task with ID {id} not found.");
            throw;
        }
    }

    //In the following cases, it loads the tasks from the JSON File. If there is no file, it creates a new list from scratch.
    public List<Task> GetAllTask()
    {
        if (!File.Exists(FileName))
        {
            return new List<Task>();
        }

        var json = File.ReadAllText(FileName);
        return JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
    }

    //Get tasks by status value.
    public List<Task> GetAllTaskByStatus(string status)
    {
        try
        {
            var json = File.ReadAllText(FileName);
            return JsonSerializer.Deserialize<List<Task>>(json).FindAll(x => x.Status == status).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine("File not found or you dont have any tasks this status.");
            throw;
        }
    }

    public void SaveTasks()
    {
        var json = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FileName, json);
    }
}