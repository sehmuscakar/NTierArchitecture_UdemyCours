using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.DataAccess.Configurations
{ // ctrl+shift+a tuşu yeni dosya açar ilgili klasör üzerinde
    internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category> // ilgili clasımızla ilgili configrasyonları yapmamızı sağlayacak
    {
        public void Configure(EntityTypeBuilder<Category> builder) // dbSet yerine daha profyonel olarak bu kullanılıyor.
        {//burda db için artık koşularımızı veriyoruz.
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Name).HasColumnType("varchar(100)");
        }
    }

    internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Price).HasColumnType("money");
        }
    }

    internal sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles");
            builder.HasKey(p => new { p.AppUserId, p.AppRoleId });//bu tablomuzda iki tane primary key olduğu için böyle yaptık
        }
    }
}
