using Microsoft.EntityFrameworkCore;
using todoap1.Entity;

namespace todoap1.Application.Commands.Queries.GetTodoById;

public class GetTodoByIdHandler
{
    private readonly TodoContext _context;

    public GetTodoByIdHandler(TodoContext context)
    {
        _context = context;
    }

    public async Task<TodoDetailDto?> Handle(
        GetTodoByIdQuery request,
        CancellationToken ct)
    {
        return await _context.TodoItems
            .Where(t => t.Id == request.Id)
            .Select(t => new TodoDetailDto
            {
                Id = t.Id,
                Title = t.Title,
                IsDone = t.IsDone,
                CategoryId = t.CategoryId
            })
            .FirstOrDefaultAsync(ct);
    }
}