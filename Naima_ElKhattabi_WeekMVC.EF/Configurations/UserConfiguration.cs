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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.ToTable("Utente");
            modelBuilder.HasKey(u => u.Id);
            modelBuilder.Property(u => u.Name).IsRequired();
            modelBuilder.Property(u => u.Username).IsRequired();
            modelBuilder.Property(u => u.Password).IsRequired();
            modelBuilder.Property(u => u.Role).IsRequired();
        }
    }
}
