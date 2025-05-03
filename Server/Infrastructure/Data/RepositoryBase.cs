using Application.Interfaces;
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
            
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {

                
                throw;
            }

        }
        public virtual async Task<T> AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<(IEnumerable<T> Items, int TotalCount)> GetPageAsync(int negocioId, int pageNumber, int pageSize, bool onlyActive = true)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            query = query.Where(e => EF.Property<int>(e, "NegocioId") == negocioId);

            if (onlyActive)
            {
                // Solo si T realmente tiene la propiedad "Activo":
                query = query.Where(e => EF.Property<bool>(e, "Activo"));
            }
            var total = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, total);
        }
        public virtual void UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public virtual void HardDeleteAsync(T entity)
        {
            try
            {

                _context.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public virtual async Task SoftDeleteAsync<TId>(TId id) where TId : notnull
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(new object[] { id });
                var property = typeof(T).GetProperty("Activo");

                if (entity != null && property != null && property.PropertyType == typeof(bool))
                {
                    property.SetValue(entity, false);
                    _context.Set<T>().Update(entity);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<T?> GetByIdAsync<TId>(TId id) where TId : notnull
        {
            try
            {
                return await _context.Set<T>().FindAsync(new object[] { id });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}