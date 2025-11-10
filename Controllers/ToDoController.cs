using Microsoft.AspNetCore. Mvc;

namespace todoap1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ToDoController : ControllerBase
    {
        private static List<TodoItem> todos = new()
        {
            new TodoItem { Id = 1, Title = "a", IsDone = false }
        };

        //get
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(todos);
        }
        
        //post
        [HttpPost]
        public IActionResult Post([FromBody] TodoItem newTodo)
        {
            newTodo.Id = todos.Max(t => t.Id) + 1;
            todos.Add(newTodo);
            return Ok(newTodo);
        }
    }
}

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsDone { get; set; }
}
        