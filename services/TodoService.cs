using Microsoft.EntityFrameworkCore;
using todoap1.Entity;
using todoap1.Models;


namespace todoap1.services;

public class TodoService
{
    private readonly TodoContext _context;

    public TodoService(TodoContext context)
    {
        _context = context;
    }
    
    // ---------------- DTO 转换 ----------------
    private TodoItemDto ToDto(TodoItem item)
    {
        return new TodoItemDto
        {
            Id = item.Id,
            Title = item.Title,
            IsComplete = item.IsDone,
            
            CategoryName = item.Category?.CategoryName,
            CategoryDescription = item.Category?.CategoryDescription,
            CategoryColor = item.Category?.CategoryColor
        };
    }
}