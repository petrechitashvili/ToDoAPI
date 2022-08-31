using ToDoAPI.Models;

namespace ToDoAPI.Service
{
    public interface ITodoService
    {
        public IEnumerable<TodoItem> GetTodoItems();

        public TodoItem GetTodoItem(long id);

        public TodoItem EditTodoItem(long id, TodoItem todoItem);

        public TodoItem CreateTodoItem(TodoItem todoItem);

        public void DeleteTodoItem(long id);
    }
}
