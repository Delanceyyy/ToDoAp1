using Microsoft.EntityFrameworkCore;
namespace todoap1.Models;

public class TodoContext: DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        :base(options)
    {
        
    }
    
    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>().HasData(
            new TodoItem { Id = 1, Title = "learn", IsDone = true }

        );
    }
    
}