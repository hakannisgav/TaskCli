using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace TaskCli.Models;

public class Task
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [JsonConstructor]
    public Task(string description, string status)
    {
        Description = description;
        Status = status;
    }
    
    public Task(Guid id, string description, string status, DateTime createdAt, [Optional] DateTime updatedAt)
    {
        Id = id;
        Description = description;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        return $"------------------------------\nID: {Id}\nDescription: {Description}\nStatus: {Status}\nCreatedAt: {CreatedAt}\nUpdatedAt: {UpdatedAt}\n------------------------------";
    }
}