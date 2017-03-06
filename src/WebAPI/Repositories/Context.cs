using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using WebAPI.Repositories.Entities;

namespace WebAPI.Repositories
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<UserOfService> UsersOfService { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SharedList> SharedLists { get; set; }
        public DbSet<SharedListComments> Comments { get; set; }
        public DbSet<SharedListData> Datas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
