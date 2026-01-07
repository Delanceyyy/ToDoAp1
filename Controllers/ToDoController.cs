using Microsoft.AspNetCore.Mvc;
using todoap1.services;
using todoap1.Application.Commands.CreateTodo;
using todoap1.Application.Commands.Queries.GetAllTodos;
using todoap1.Models;
using todoap1.Application.Commands.Queries.GetTodoById;
using todoap1.Application.Commands.DeleteTodo;
using todoap1.Application.Commands.UpdateTodo;

namespace todoap1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController(TodoService service, CreateTodoHandler createTodoHandler, GetTodoByIdHandler getByIdHandler, GetAllTodosHandler getAllTodosHandler, UpdateTodoHandler updateTodoHandler, DeleteTodoHandler deleteTodoHandler
    ) : ControllerBase
    {
        //get🚩
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var todos = await getAllTodosHandler.Handle(new GetAllTodosQuery(), ct);
            return Ok(todos);
        }
        
        //get id🚩
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken ct)
        {
            var todo = await getByIdHandler.Handle(new GetTodoByIdQuery(id), ct);
            return todo == null ? NotFound() : Ok(todo);
        }
        
        //post🚩
        [HttpPost]
        public async Task<IActionResult> CreateTodo(CreateTodoCommand command, CancellationToken ct)
        {
            var id = await createTodoHandler.Handle(command, ct);
            return CreatedAtAction(nameof(Get), new { id = id }, id);
        }
        
        //put🚩
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,  UpdateTodoCommand command, CancellationToken ct)
        {
            command.Id = id;
            var ok = await updateTodoHandler.Handle(command, ct);
            return ok ? NoContent() : NotFound();
        }
        
        //delete🚩
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken ct)
        {
            var ok = await deleteTodoHandler.Handle(new DeleteTodoCommand(id), ct);
            return ok ? NoContent() : NotFound();
        }
    }
}
     





   