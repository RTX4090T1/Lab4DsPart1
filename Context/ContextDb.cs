using ConsoleApp24.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Context
{
    public class ContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionStringHere"); 
        }
        public DbSet<Goods> ScrapedData { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Cookies> Cookies { get; set; }
        public DbSet<Selected> Selected { get; set; }
    }
}
