using Microsoft.EntityFrameworkCore;
using Roomy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Data
{
    public class RoomyDbContext : DbContext
    {
        public RoomyDbContext(DbContextOptions<RoomyDbContext> options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(x => x.Mail).IsUnique();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Room> Rooms { get; set; }
    }
}
