using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Models
{
    public interface ITodoContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public IEnumerable<TodoItem> GetList();

        public TodoItem? GetById(long id);

        public TodoItem? Update(long id, TodoItem todoItem);
        public void Create(TodoItem todoItem);
        public TodoItem? Delete(long id);
    }
}
