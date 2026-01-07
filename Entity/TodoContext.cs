using Microsoft.EntityFrameworkCore;
namespace todoap1.Entity;

public class TodoContext: DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        :base(options)
    {
        
    }
    
    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>()
            .HasOne(t => t.Category)
            .WithMany(c => c.Todos)
            .HasForeignKey(t => t.CategoryId);

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Study", CategoryDescription = "Study Backend", CategoryColor = "#FF0000" },
            new Category { CategoryId = 2, CategoryName = "Work", CategoryDescription = "Work Work", CategoryColor = "#00FF00" },
            new Category { CategoryId = 3, CategoryName = "Fun", CategoryDescription = "Relax", CategoryColor = "#0000FF" }
        );
        
        modelBuilder.Entity<TodoItem>().HasData(
            new TodoItem { Id = 1, Title = "learn", IsDone = true }

        );
    }
    
}