using Microsoft.EntityFrameworkCore;
using OrderWebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderWebApi
{
    public class AppContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=OrderDB;Trusted_Connection=True;");
        }
    }
}
