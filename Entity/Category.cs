namespace todoap1.Entity;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string? CategoryDescription { get; set; }
    public string CategoryColor { get; set; }
    
    public ICollection<TodoItem> Todos { get; set; } =  new List<TodoItem>();
}