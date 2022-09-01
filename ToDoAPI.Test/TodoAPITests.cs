using Moq;
using TodoApi.Models;
using ToDoAPI.Models;
using ToDoAPI.Service;

namespace ToDoAPI.Test
{
    public class TodoAPITests
    {
        private readonly Mock<TodoContext> _todoContextMock;
        private readonly TodoService _todoService;
        public TodoAPITests()
        {
            _todoContextMock = new Mock<TodoContext>(null);
            _todoService = new TodoService(_todoContextMock.Object);
        }
        [Fact]
        public void CreateTodoItemEmptyNameTest()
        {
            var todoItem = new TodoItem() {Name = null, Description = "test", ActivityType = ActivityTypeEnum.Productive, IsComplete = true };

            try
            {
                //_todoService.Setup(x => x.CreateTodoItem(todoItem));
                //_todoService.Object.CreateTodoItem(todoItem);
                _todoService.CreateTodoItem(todoItem);
            }
            catch(Exception ex)
            {
                Assert.Equal("Name can't be empty! yeaa", ex.Message);
            }

        }
    }
}