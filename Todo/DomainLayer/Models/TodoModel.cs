namespace DomainLayer.Models;
public class TodoModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
}

