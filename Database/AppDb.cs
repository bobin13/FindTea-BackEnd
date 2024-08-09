using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindTeaBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace FindTeaBackEnd.Database
{
    public class AppDb : DbContext
    {

        public DbSet<Store> Stores { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=;Database=tims");
        }


    }
}