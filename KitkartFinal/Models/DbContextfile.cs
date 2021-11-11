using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitkartFinal.Models
{
    public class DbContextfile:DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbContextfile()
        {
        }

        public DbContextfile(DbContextOptions<DbContextfile> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=divyeshs.database.windows.net;Database=newdb;uid=login;password=12345678@a");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }


    }
}

