using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Domain.Domain;

namespace TodoAPI.Domain.Repository
{
    public interface ITodoRepository
    {
        public IEnumerable<TodoItem> GetList();

        public TodoItem? GetById(long id);

        public TodoItem? Update(long id, TodoItem todoItem);
        public void Create(TodoItem todoItem);
        public TodoItem? Delete(long id);
    }
}
