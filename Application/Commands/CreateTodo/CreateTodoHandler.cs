using todoap1.Entity;

namespace todoap1.Application.Commands.CreateTodo;

public class CreateTodoHandler
{
    private readonly TodoContext _db;

    public CreateTodoHandler(TodoContext db)
    {
        _db = db;
    }

    public async Task<int> Handle(CreateTodoCommand command, CancellationToken ct)
    {
        var todo = new TodoItem
        {
            Title = command.Title,
            IsDone = command.IsComplete,
            CategoryId = command.CategoryId
        };

        _db.TodoItems.Add(todo);
        await _db.SaveChangesAsync(ct);

        return todo.Id;
    }
}