namespace todoap1.Models;

public class TodoItemDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsComplete { get; set; }
    
    public int? CategoryId { get; set; }
    public string? CategoryColor { get; set; }
    public string? CategoryDescription { get; set; }
    public string? CategoryName {get;set;}
}