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

        public void Update(long id, TodoItem todoItem)
        {
            var todoObject = TodoItems.Where(x => x.Id == id).FirstOrDefault();

            if (todoObject is null)
            {
                throw new Exception("item not found!");
            }

            if (todoObject != null)
            {
                todoObject.Name = todoItem.Name;
                todoObject.Description = todoItem.Description;
                todoObject.ActivityType = todoItem.ActivityType;
                todoObject.IsComplete = todoItem.IsComplete;
                todoObject.LastModifiedDate = DateTime.Now;
                base.SaveChanges();
            }
        }

        public void Create(TodoItem todoItem)
        {
            TodoItems.Add(todoItem);
            base.SaveChanges();
        }

        public void Delete(long id)
        {
            var todoItem = TodoItems.Where(x => x.Id == id).FirstOrDefault();
            todoItem.DeleteDate = DateTime.Now;
            base.SaveChanges();
        }
    }
}