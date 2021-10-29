using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Naima_ElKhattabi_WeekMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.EF.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> modelBuilder)
        {
            modelBuilder.ToTable("Dish"); //specifico il nome della tabella
            modelBuilder.HasKey(d=> d.Id); //specifico la chiave primaria
            modelBuilder.Property(d=> d.Name).IsRequired();
            modelBuilder.Property(d=> d.Description).IsRequired();
            modelBuilder.Property(d=> d.Type).IsRequired();
            modelBuilder.Property(d=> d.Price).IsRequired();

            //Relazione Menu 1 ->Dish n
            modelBuilder.HasOne(d=> d.Menu).WithMany(m=> m.Dishes).HasForeignKey(m=> m.Id);
        }
    }
}
