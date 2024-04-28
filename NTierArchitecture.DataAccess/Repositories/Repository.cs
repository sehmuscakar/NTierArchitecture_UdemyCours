using Microsoft.EntityFrameworkCore;
using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.DataAccess.Repositories
{
    internal  class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
           return await _context.Set<T>().AnyAsync(expression, cancellationToken);//bu geriye true yada false dönecek
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken=default)
        {
            return await _context.Set<T>().Where(expression).FirstOrDefaultAsync(cancellationToken);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().AsNoTracking().Where(expression).AsQueryable();
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }

    internal sealed class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) // burdaki constractır base gönderir base de generic olan repositoryde işlem yaptırır.
        {


        }
    }

    internal sealed class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) 
        {


        }
    }

    internal sealed class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {


        }
    }
}
