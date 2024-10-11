namespace DomainLayer.Dto;

public class CreateTask 
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}


public class UpdateTask // can change name or description or nothing.
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}