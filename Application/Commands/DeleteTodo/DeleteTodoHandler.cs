using todoap1.Entity;

namespace todoap1.Application.Commands.DeleteTodo;

public class DeleteTodoHandler
{
    private readonly TodoContext _context;

    public DeleteTodoHandler(TodoContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken ct)
    {
        var todo = await _context.TodoItems.FindAsync(new object[] { request.Id }, ct);

        if (todo is null)
            return false;

        _context.TodoItems.Remove(todo);

        await _context.SaveChangesAsync(ct);
        return true;
    }
}