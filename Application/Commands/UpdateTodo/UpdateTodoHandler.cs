using todoap1.Entity; 

namespace todoap1.Application.Commands.UpdateTodo;

public class UpdateTodoHandler
{
    private readonly TodoContext _context;

    public UpdateTodoHandler(TodoContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateTodoCommand request, CancellationToken ct)
    {
        var todo = await _context.TodoItems.FindAsync(new object[] { request.Id }, ct);

        if (todo is null)
            return false;

        todo.Title = request.Title;
        todo.IsDone = request.IsDone;
        todo.CategoryId = request.CategoryId;

        await _context.SaveChangesAsync(ct);
        return true;
    }
}