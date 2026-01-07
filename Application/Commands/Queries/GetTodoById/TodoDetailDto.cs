namespace todoap1.Application.Commands.Queries.GetTodoById;

public class TodoDetailDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; }

    public int? CategoryId { get; set; }
}
