using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;
using TodoApi.Models;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        // GET: api/TodoItems
        [HttpGet]
        public IEnumerable<TodoItem> GetTodoItems()
        {
            return _context.TodoItems.ToList();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItem(long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                return _context.TodoItems.FirstOrDefault(x => x.Id == id);
            }
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutTodoItem(long id, TodoItem todoItem)
        {
            var todoObject = _context.TodoItems.Where(x => x.Id == id).FirstOrDefault();

            todoObject.Name = todoItem.Name;
            todoObject.Description = todoItem.Description;
            todoObject.ActivityType = todoItem.ActivityType;
            todoObject.IsComplete = todoItem.IsComplete;
            _context.SaveChanges();
            return Ok(todoObject);

        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<TodoItem> PostTodoItem(TodoItem todoItem)
        {
            _context.Add(todoItem);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public void DeleteTodoItem(long id)
        {
            TodoItem todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == id);

            _context.Remove(todoItem);

            _context.SaveChanges();
        }

        private bool TodoItemExists(long id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
