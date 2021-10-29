using Microsoft.EntityFrameworkCore;
using Naima_ElKhattabi_WeekMVC.Core;
using Naima_ElKhattabi_WeekMVC.Core.Models;
using Naima_ElKhattabi_WeekMVC.EF.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.EF
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<User> Users { get; set; }

        public RestaurantContext() { }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Restaurant; Trusted_Connection = True;");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Menu>(new MenuConfiguration());
            modelBuilder.ApplyConfiguration<Dish>(new DishConfiguration());
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        }
    }
}
