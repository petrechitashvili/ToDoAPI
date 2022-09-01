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
            return _context.TodoItems.ToList().Where(x => x.DeleteDate is null);
        }

        public TodoItem GetTodoItem(long id)
        {
            if (id == 0)
            {
                throw new Exception("id can't be zero");
            }

            var todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == id);

            if (todoItem == null)
            {
                throw new Exception("Record not found!");
            }

            return todoItem;
        }

        public TodoItem EditTodoItem(long id, TodoItem todoItem)
        {
            var todoObject = _context.TodoItems.Where(x => x.Id == id).FirstOrDefault();

            if (todoObject is null) 
            { 
                throw new Exception("item not found!"); 
            }
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
                throw new Exception("IsComplete can't be empty");
            }
            else
            {
                todoObject.Name = todoItem.Name;
                todoObject.Description = todoItem.Description;
                todoObject.ActivityType = todoItem.ActivityType;
                todoObject.IsComplete = todoItem.IsComplete;
                todoObject.LastModifiedDate = DateTime.Now;
                _context.SaveChanges();
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
                throw new Exception("IsComplete can't be empty");
            }

            todoItem.CreateDate = DateTime.Now;

            _context.Add(todoItem);

            _context.SaveChanges();

            return todoItem;
        }

        public void DeleteTodoItem(long id)
        {
            var todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == id);

            if (todoItem is null)
            {
                throw new Exception("Record not found!");
            }
            else
            {
                todoItem.DeleteDate = DateTime.Now;

                _context.SaveChanges();
            }
        }
    }
}
