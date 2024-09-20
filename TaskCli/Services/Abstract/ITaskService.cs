namespace TaskCli.Services;
using Task = TaskCli.Models.Task;

public interface ITaskService
{
    void AddTask(string description);
    void UpdateTask(Guid id, string newDescription, string status);
    void DeleteTask(Guid id);
    List<Task> GetAllTask();
    List<Task> GetAllTaskByStatus(string status);
    void SaveTasks();
}