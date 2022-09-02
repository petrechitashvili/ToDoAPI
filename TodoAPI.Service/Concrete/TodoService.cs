using TodoAPI.Domain.Domain;
using TodoAPI.Domain.Repository;

namespace ToDoAPI.Service
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;
        public TodoService(ITodoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
        }

        public IEnumerable<TodoItem> GetTodoItems()
        {
            return _repository.GetList();
        }

        public TodoItem GetTodoItem(long id)
        {
            if (id == 0)
            {
                throw new Exception("id can't be zero");
            }

            var todoItem = _repository.GetById(id);

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

            var todoObject = _repository.Update(id, todoItem);

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

            _repository.Create(todoItem);

            return todoItem;
        }

        public void DeleteTodoItem(long id)
        {
            var todoItem = _repository.Delete(id);

            if (todoItem is null)
            {
                throw new Exception("Record not found!");
            }
        }
    }
}
