using TodoApi.Models;
using ToDoAPI.Models;

namespace ToDoAPI.Service
{
    public class TodoService : ITodoService
    {
        private readonly TodoContext _context;
        public TodoService(TodoContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public IEnumerable<TodoItem> GetTodoItems()
        {
            return _context.TodoItems.ToList();
        }

        public TodoItem GetTodoItem(long id)
        {
            if (id == 0)
            {
                throw new Exception("id can't be zero");
            }
            else
            {
                return _context.TodoItems.FirstOrDefault(x => x.Id == id);
            }
        }

        public TodoItem EditTodoItem(long id, TodoItem todoItem)
        {
            var todoObject = _context.TodoItems.Where(x => x.Id == id).FirstOrDefault();
            if (todoObject == null) 
            { 
                throw new Exception("item not found!"); 
            }

            todoObject.Name = todoItem.Name;
            todoObject.Description = todoItem.Description;
            todoObject.ActivityType = todoItem.ActivityType;
            todoObject.IsComplete = todoItem.IsComplete;
            _context.SaveChanges();
            return todoObject;
        }

        public TodoItem CreateTodoItem(TodoItem todoItem)
        {
            if(string.IsNullOrEmpty(todoItem.Name))
            {
                throw new Exception("Name can't be empty!");
            }

            _context.Add(todoItem);

            _context.SaveChanges();

            return todoItem;
        }

        public void DeleteTodoItem(long id)
        {
            TodoItem todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == id);

            _context.Remove(todoItem);

            _context.SaveChanges();
        }

    }
}
