using Microsoft.EntityFrameworkCore;
using todoap1.Application.Commands.CreateTodo;
using todoap1.Application.Commands.DeleteTodo;
using todoap1.Application.Commands.Queries.GetTodoById;
using todoap1.Application.Commands.Queries.GetAllTodos;
using todoap1.Application.Commands.UpdateTodo;
using todoap1.services;
using todoap1.Entity;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoConnectionString")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<TodoService>();
builder.Services.AddScoped<GetTodoByIdHandler>();
builder.Services.AddScoped<GetAllTodosHandler>();
builder.Services.AddScoped<CreateTodoHandler>();
builder.Services.AddScoped<UpdateTodoHandler>();
builder.Services.AddScoped<DeleteTodoHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .AllowAnyOrigin()      // 允许任何来源
            .AllowAnyHeader()      // 允许任何 Header
            .AllowAnyMethod();     // 允许 GET/POST/PUT/DELETE
    });
});

var app = builder.Build();

app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();




