namespace TaskCli.Services;
using Task = TaskCli.Models.Task;

public interface ITaskService
{
    void AddTask(string description, string status);
    void UpdateTask(Guid id, string newDescription, string status);
    void DeleteTask(Guid id);
    void GetAllTask();
    void GetAllTaskByStatus(string status);
    void SaveTasks();
}