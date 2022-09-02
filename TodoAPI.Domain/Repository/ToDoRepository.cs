using TodoApi.Models;
using TodoAPI.Domain.Domain;

namespace TodoAPI.Domain.Repository
{

    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;
        public TodoRepository(TodoContext todoContext)
        {
            _context = todoContext;
        }

        public IEnumerable<TodoItem> GetList()
        {
            return _context.TodoItems.ToList().Where(x => x.DeleteDate is null);
        }

        public TodoItem? GetById(long id)
        {
            return _context.TodoItems.FirstOrDefault(x => x.Id == id);
        }

        public TodoItem? Update(long id, TodoItem todoItem)
        {
            var todoObject = _context.TodoItems.Where(x => x.Id == id).FirstOrDefault();

            if (todoObject is null)
            {
                return null;
            }
            else
            {
                todoObject.Name = todoItem.Name;
                todoObject.Description = todoItem.Description;
                todoObject.ActivityType = todoItem.ActivityType;
                todoObject.IsComplete = todoItem.IsComplete;
                todoObject.LastModifiedDate = DateTime.Now;
                _context.SaveChanges();
                return todoObject;
            }
        }

        public void Create(TodoItem todoItem)
        {
            todoItem.CreateDate = DateTime.Now;
            _context.TodoItems.Add(todoItem);
            _context.SaveChanges();
        }

        public TodoItem? Delete(long id)
        {
            var todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if (todoItem is null)
            {
                return null;
            }
            todoItem.DeleteDate = DateTime.Now;
            _context.SaveChanges();
            return todoItem;
        }
    }
}
