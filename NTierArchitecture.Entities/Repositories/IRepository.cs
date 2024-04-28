using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Entities.Repositories
{
    //Generic Repository
    //Repository Pattern uyguladık , ripository disayn paren 
    public interface IRepository<T>
    {
        Task AddAsync(T entity,CancellationToken cancellationToken=default); //asekronik metotlar kullanacaksan CancellationToken bu sınıfı kullan yoksa hata alırsın
        //default kullanmak zorunlu değil gibisinden
        void Update(T entity); // bu asekronik olmaz 
        void Remove(T entity); //buda asekronik olmaz
        Task<T> GetByIdAsync(Expression<Func<T,bool>> expression,CancellationToken cancellationToken=default); //Expression bu kodu almamızı yapmamızı sağlar // p=>p.name==
        IQueryable<T> GetAll();

        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);// benim gönderdiğim sorguya göre bana true yada false gönderecek

    }

    public interface ICategoryRepository : IRepository<Category> // bunları farklı bir dosyayada ekleyebilirsin
    {


    }
    public interface IProductRepository : IRepository<Product>
    {

    }
    public interface IUserRoleRepository: IRepository<UserRole>
    {

    }


    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken=default); // bunu aynn bu şekil yazman lazım 
    }

   

}
