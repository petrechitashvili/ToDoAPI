using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Models
{
    public interface ITodoContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public void Update(long id, TodoItem todoItem);
        public void Create(TodoItem todoItem);
        public void Delete(long id);
    }
}
