using Microsoft.EntityFrameworkCore;
using TodoListAPI.Models;

namespace TodoListAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoSubList> TodoSubLists { get; set; }

    }
}
