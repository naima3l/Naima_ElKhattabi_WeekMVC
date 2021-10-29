using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Naima_ElKhattabi_WeekMVC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.EF.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> modelBuilder)
        {
            modelBuilder.ToTable("Menu");
            modelBuilder.HasKey(m => m.Id);
            modelBuilder.Property(m=> m.Name).IsRequired();

            //Relazione Menu 1 ->Dish n
            modelBuilder.HasMany(m => m.Dishes).WithOne(d => d.Menu).HasForeignKey(d=> d.MenuId);

        }
    }
}
