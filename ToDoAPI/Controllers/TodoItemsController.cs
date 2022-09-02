using Microsoft.AspNetCore.Mvc;
using TodoAPI.Domain.Domain;
using ToDoAPI.Service;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoItemsController(ITodoService service)
        {
            _todoService = service;
        }

        // GET: api/TodoItems
        [HttpGet]
        public IEnumerable<TodoItem> GetTodoItems()
        {
            return _todoService.GetTodoItems();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItem(long id)
        {
            try
            {
                return _todoService.GetTodoItem(id);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<TodoItem> EditTodoItem(long id, TodoItem todoItem)
        {
            try
            {
                return _todoService.EditTodoItem(id, todoItem);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create")]
        public ActionResult<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            try
            {
                return _todoService.CreateTodoItem(todoItem);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTodoItem(long id)
        {
            try
            {
                _todoService.DeleteTodoItem(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
