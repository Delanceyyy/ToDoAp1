using Microsoft.EntityFrameworkCore;
using todoap1.Entity;

namespace todoap1.Application.Commands.Queries.GetAllTodos;

public class GetAllTodosHandler
{
    private readonly TodoContext _context;

    public GetAllTodosHandler(TodoContext context)
    {
        _context = context;
    }

    public async Task<List<TodoListItemDto>> Handle(
        GetAllTodosQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.TodoItems
            .Include(t => t.Category) // ✅ 加载导航属性
            .Select(t => new TodoListItemDto
            {
                Id = t.Id,
                Title = t.Title,
                IsDone = t.IsDone,
                CategoryId = t.CategoryId,

                // ✅ 关键：字段名与 Category 实体一致
                CategoryName = t.Category != null
                    ? t.Category.CategoryName
                    : null,

                CategoryColor = t.Category != null
                    ? t.Category.CategoryColor
                    : null
            })
            .ToListAsync(cancellationToken);
    }
}