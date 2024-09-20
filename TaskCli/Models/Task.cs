using System.Runtime.InteropServices;

namespace TaskCli.Models;

public class Task
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Task(string description)
    {
        Description = description;
    }
    
    public Task(Guid id, string description, string status, DateTime createdAt, [Optional] DateTime updatedAt)
    {
        Id = id;
        Description = description;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}