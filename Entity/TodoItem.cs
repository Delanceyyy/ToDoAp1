namespace todoap1.Entity;

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsDone { get; set; }
    
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
}