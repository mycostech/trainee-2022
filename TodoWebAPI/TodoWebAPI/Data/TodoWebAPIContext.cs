#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Models;

namespace TodoWebAPI.Data
{
    public class TodoWebAPIContext : DbContext
    {
        public TodoWebAPIContext (DbContextOptions<TodoWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<TodoWebAPI.Models.TodoList> TodoList { get; set; }
        public DbSet<TodoWebAPI.Models.TodoTask> TodoTask { get; set; }
    }
}
