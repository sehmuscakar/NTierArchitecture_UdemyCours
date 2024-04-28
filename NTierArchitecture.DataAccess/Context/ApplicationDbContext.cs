using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.DataAccess.Context
{
    //intürnıl katman içinde tek erişilebilirilik anlamına geliyor. context oyle olması lazım 
    internal sealed class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>,IUnitOfWork // Iunitofwork te implement iztemez sebebi ise savechanges kodları olmasıdır.
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //  builder.Entity<Product>().ToTable("Product"); // buda dbset ile aynı mantık
            //bunlar ıdentity tabloomuzda oluşmasını engelediğimiz tablololarımız
            builder.Ignore<IdentityUserLogin<Guid>>();
            builder.Ignore<IdentityUserRole<Guid>>();
            builder.Ignore<IdentityUserClaim<Guid>>();
            builder.Ignore<IdentityUserToken<Guid>>();
            builder.Ignore<IdentityRoleClaim<Guid>>();

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);//bu bizim configuration dosyalarımıza gidiyor veritabanı oluşmasını otomatik yapıyor

        
        }
    }
}
