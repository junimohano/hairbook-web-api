using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairbookWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HairbookWebApi.Db
{
    public class HairbookContext : DbContext
    {
        public HairbookContext(DbContextOptions<HairbookContext> options) : base(options)
        {
        }

        public DbSet<User> Boards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
