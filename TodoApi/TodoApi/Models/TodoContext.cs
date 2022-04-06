using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TodoApi.Models;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;

        public DbSet<TodoApi.Models.Step> Step { get; set; }

        public virtual DbSet<User> User { get; set; }
    }
}