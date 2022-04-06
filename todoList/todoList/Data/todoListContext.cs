#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todoAPI.Model;

namespace todoAPI.Data
{
    public class todoListContext : DbContext
    {
        public todoListContext (DbContextOptions<todoListContext> options)
            : base(options)
        {
        }

        public DbSet<todoAPI.Model.TodoList> TodoList { get; set; }

        public DbSet<todoAPI.Model.Comment> Comment { get; set; }

        public DbSet<todoAPI.Model.Task> Task { get; set; }
    }
}
