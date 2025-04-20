using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbContext _context;
        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();

        }
        public virtual async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }
        public virtual async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public virtual async Task HardDeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public virtual async Task SoftDeleteAsync<TId>(TId id) where TId : notnull
        {
            var entity = await _context.Set<T>().FindAsync(new object[] { id });
            var property = typeof(T).GetProperty("Activo");

            if (entity != null && property != null && property.PropertyType == typeof(bool))
            {
                property.SetValue(entity, false);
                _context.Set<T>().Update(entity);
            }
        }

        public virtual async Task<T?> GetByIdAsync<TId>(TId id) where TId : notnull
        {
            return await _context.Set<T>().FindAsync(new object[] { id });
        }
        
    }
}