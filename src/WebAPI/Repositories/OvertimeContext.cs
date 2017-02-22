using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repositories
{
    public class OvertimeContext : DbContext
    {
        public OvertimeContext(DbContextOptions<OvertimeContext> options) : base(options)
        {

        }

        public DbSet<DayEvent> DayEvents { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DayEvent>().ToTable("DayEvent");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
