using Moq;
using TodoApi.Models;
using ToDoAPI.Models;
using ToDoAPI.Service;

namespace ToDoAPI.Test
{
    public class TodoAPITests
    {
        private readonly Mock<ITodoContext> _todoContextMock;
        private readonly TodoService _todoService;
        public TodoAPITests()
        {
            _todoContextMock = new Mock<ITodoContext>();
            _todoService = new TodoService(_todoContextMock.Object);
        }
        [Fact]
        public void CreateTodoItem_null_Name_Test()
        {
            var todoItem = new TodoItem() {Name = null, Description = "test", ActivityType = ActivityTypeEnum.Productive, IsComplete = true };

            try
            {
                _todoService.CreateTodoItem(todoItem);
            }
            catch(Exception ex)
            {
                Assert.Equal("Name can't be empty!", ex.Message);
            }
        }

        [Fact]
        public void CreateTodoItem_Empty_Name_Test()
        {
            var todoItem = new TodoItem() { Name = "", Description = "test", ActivityType = ActivityTypeEnum.Productive, IsComplete = true };

            try
            {
                _todoService.CreateTodoItem(todoItem);
            }
            catch (Exception ex)
            {
                Assert.Equal("Name can't be empty!", ex.Message);
            }
        }

        [Fact]
        public void CreateTodoItem_Empty_ActivityType_Test()
        {
            var todoItem = new TodoItem() { Name = "test", Description = "test", ActivityType = null, IsComplete = true };

            try
            {
                _todoService.CreateTodoItem(todoItem);
            }
            catch (Exception ex)
            {
                Assert.Equal("ActivityType can't be empty!", ex.Message);
            }
        }

        [Fact]
        public void CreateTodoItem_Empty_IsComplete_Test()
        {
            var todoItem = new TodoItem() { Name = "test", Description = "test", ActivityType = ActivityTypeEnum.Productive, IsComplete = null };

            try
            {
                _todoService.CreateTodoItem(todoItem);
            }
            catch (Exception ex)
            {
                Assert.Equal("IsComplete can't be empty!", ex.Message);
            }
        }

        [Fact]
        public void CreateTodoItem_CreateDate_Assigned_Test()
        {
            var todoItem = new TodoItem() { Name = "test", Description = "test", ActivityType = ActivityTypeEnum.Productive, IsComplete = true };

            var todoObject = _todoService.CreateTodoItem(todoItem);

            Assert.True(todoObject.CreateDate != null);
        }

        [Fact]
        public void EditTodoItem_Empty_Name_Test()
        {
            var todoObject = new TodoItem() { Name = "", Description = "test", ActivityType = ActivityTypeEnum.Productive, IsComplete = true };

            try
            {
                _todoService.EditTodoItem(1, todoObject);
            }
            catch (Exception ex)
            {
                Assert.Equal("Name can't be empty!", ex.Message);
            }
        }

        [Fact]
        public void EditTodoItem_null_Name_Test()
        {
            var todoObject = new TodoItem() { Name = null, Description = "test", ActivityType = ActivityTypeEnum.Productive, IsComplete = true };

            try
            {
                _todoService.EditTodoItem(1, todoObject);
            }
            catch (Exception ex)
            {
                Assert.Equal("Name can't be empty!", ex.Message);
            }
        }

        [Fact]
        public void EditTodoItem_Empty_ActivityType_Test()
        {
            var todoItem = new TodoItem() { Name = "test", Description = "test", ActivityType = null, IsComplete = true };

            try
            {
                _todoService.EditTodoItem(1, todoItem);
            }
            catch (Exception ex)
            {
                Assert.Equal("ActivityType can't be empty!", ex.Message);
            }
        }

        [Fact]
        public void EditTodoItem_Empty_IsComplete_Test()
        {
            var todoItem = new TodoItem() { Name = "test", Description = "test", ActivityType = ActivityTypeEnum.Productive, IsComplete = null };

            try
            {
                _todoService.EditTodoItem(1, todoItem);
            }
            catch (Exception ex)
            {
                Assert.Equal("IsComplete can't be empty!", ex.Message);
            }
        }

    }
}