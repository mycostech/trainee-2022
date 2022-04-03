#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todoapp_api.Models;

namespace todoapp_api.Data
{
    public class todoapp_apiContext : DbContext
    {
        public todoapp_apiContext (DbContextOptions<todoapp_apiContext> options)
            : base(options)
        {
        }

        public DbSet<todoapp_api.Models.User> User { get; set; }

        public DbSet<todoapp_api.Models.Item> Item { get; set; }

        public DbSet<todoapp_api.Models.SubItem> SubItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().Property(i => i.Priority).HasDefaultValue(5);
            modelBuilder.Entity<Item>().Property(i => i.IsCompleted).HasDefaultValue(false);
            modelBuilder.Entity<Item>().Property(i => i.Color).HasDefaultValue("#1A1A1A");
            modelBuilder.Entity<SubItem>().Property(i => i.IsCompleted).HasDefaultValue(false);
        }
    }
}
