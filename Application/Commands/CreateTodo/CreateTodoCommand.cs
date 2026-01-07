namespace todoap1.Application.Commands.CreateTodo;

public class CreateTodoCommand
{
    public string Title { get; set; } = "";
    public bool IsComplete { get; set; }
    public int? CategoryId { get; set; }
}