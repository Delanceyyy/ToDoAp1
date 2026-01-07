namespace todoap1.Application.Commands.UpdateTodo;

public class UpdateTodoCommand
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsDone { get; set; }
    public int? CategoryId { get; set; }
}




