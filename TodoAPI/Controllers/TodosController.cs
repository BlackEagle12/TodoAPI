using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Data.Models;
using Todo.Services.TodoService;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    { 
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> getTodos()
        {
            var todos = await _todoService.GetTodos();
            return Ok(todos);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> getTodo(int id)
        {
            var todo = await _todoService.GetTodo(id);
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] Todo.Data.Models.Todo todo)
        {
            var isAdded = await _todoService.AddTodo(todo);
            return Ok(isAdded);
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] int id, [FromBody] Todo.Data.Models.Todo todo)
        {
            var isUpdated = await _todoService.UpdateTodo(id, todo);
            return Ok(isUpdated);
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var isDeleted = await _todoService.DeleteTodo(id);
            return Ok(isDeleted);
        }
    }
}
