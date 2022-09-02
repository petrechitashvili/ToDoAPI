using Microsoft.EntityFrameworkCore;
using TodoAPI.Domain.Domain;

namespace TodoApi.Models
{
    public class TodoContext :  DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;

    }
}