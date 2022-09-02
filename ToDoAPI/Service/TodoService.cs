using TodoApi.Models;
using ToDoAPI.Models;

namespace ToDoAPI.Service
{
    public class TodoService : ITodoService
    {
        private readonly ITodoContext _context;
        public TodoService(ITodoContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public IEnumerable<TodoItem> GetTodoItems()
        {
            return _context.GetList();
        }

        public TodoItem GetTodoItem(long id)
        {
            if (id == 0)
            {
                throw new Exception("id can't be zero");
            }

            var todoItem = _context.GetById(id);

            if (todoItem == null)
            {
                throw new Exception("Record not found!");
            }

            return todoItem;
        }

        public TodoItem EditTodoItem(long id, TodoItem todoItem)
        {
            if (string.IsNullOrEmpty(todoItem.Name))
            {
                throw new Exception("Name can't be empty!");
            }
            if(todoItem.ActivityType is null)
            {
                throw new Exception("ActivityType can't be empty!");
            }
            if(todoItem.IsComplete is null)
            {
                throw new Exception("IsComplete can't be empty!");
            }

            var todoObject = _context.Update(id, todoItem);

            if(todoObject is null)
            {
                throw new Exception("Record not found!");
            }

            return todoObject;
        }

        public TodoItem CreateTodoItem(TodoItem todoItem)
        {
            if(string.IsNullOrEmpty(todoItem.Name))
            {
                throw new Exception("Name can't be empty!");
            }
            if (todoItem.ActivityType is null)
            {
                throw new Exception("ActivityType can't be empty!");
            }
            if (todoItem.IsComplete is null)
            {
                throw new Exception("IsComplete can't be empty!");
            }

            _context.Create(todoItem);

            return todoItem;
        }

        public void DeleteTodoItem(long id)
        {
            var todoItem = _context.Delete(id);

            if (todoItem is null)
            {
                throw new Exception("Record not found!");
            }
        }
    }
}
