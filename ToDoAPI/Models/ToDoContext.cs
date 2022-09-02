using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using ToDoAPI.Models;

namespace TodoApi.Models
{
    public class TodoContext :  DbContext, ITodoContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
           // LoadTodoItems();
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;

        //public void LoadTodoItems()
        //{
        //    var todoItem1 = new TodoItem() { Name = "test", Description = "for testing", ActivityType = ActivityTypeEnum.Productive, IsComplete = true };
        //    var todoItem2 = new TodoItem() { Name = "test 2", Description = "for testing 2", ActivityType = ActivityTypeEnum.Relaxing, IsComplete = false };
        //    var todoItem3 = new TodoItem() { Name = "test 3", Description = "for testing 3", ActivityType = ActivityTypeEnum.Wasting, IsComplete = true };

        //    TodoItems.Add(todoItem1);
        //    TodoItems.Add(todoItem2);
        //    TodoItems.Add(todoItem3);
        //}

        //public List<TodoItem> GetTodoItems()
        //{
        //    return TodoItems.Local.ToList();
        //}

        public IEnumerable<TodoItem> GetList()
        {
            return TodoItems.ToList().Where(x => x.DeleteDate is null);
        }

        public TodoItem? GetById(long id)
        {
            return TodoItems.FirstOrDefault(x => x.Id == id);
        }

        public TodoItem? Update(long id, TodoItem todoItem)
        {
            var todoObject = TodoItems.Where(x => x.Id == id).FirstOrDefault();

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
                base.SaveChanges();
                return todoObject;
            }
        }

        public void Create(TodoItem todoItem)
        {
            todoItem.CreateDate = DateTime.Now;
            TodoItems.Add(todoItem);
            base.SaveChanges();
        }

        public TodoItem? Delete(long id)
        {
            var todoItem = TodoItems.FirstOrDefault(x => x.Id == id);
            if (todoItem is null)
            {
                return null;
            }
            todoItem.DeleteDate = DateTime.Now;
            base.SaveChanges();
            return todoItem;
        }
    }
}