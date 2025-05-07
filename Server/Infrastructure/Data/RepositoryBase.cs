using Application.Interfaces;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbContext _context;
        private readonly ILoggerApp _logger;
        public RepositoryBase(DbContext context, ILoggerApp logger)
        {
            _context = context;
            _logger = logger;
        }

        public virtual async Task<List<T>> ListAsync()
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método ListAsync desde el RepositoryBase para la entidad {typeof(T).Name}");
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método ListAsync desde el RepositoryBase para la entidad {typeof(T).Name}. Error: {ex}");
                throw;
            }

        }
        public virtual async Task<T> AddAsync(T entity)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método AddAsync desde el RepositoryBase para la entidad {entity}");
            try
            {
                await _context.Set<T>().AddAsync(entity);
                _logger.LogInfo(this.GetType().Name, $"Se ejecutó con éxito el método AddAsync desde el RepositoryBase para la entidad {entity}");
                return entity;
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
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error al intentar agregar un nuevo registro en el método AddAsync desde el RepositoryBase para la entidad {entity}. Error: {ex}");
                throw;
            }

        }
        public virtual void UpdateAsync(T entity)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método UpdateAsync desde el RepositoryBase para la entidad {entity}");
            try
            {
                _context.Set<T>().Update(entity);
                _logger.LogInfo(this.GetType().Name, $"Se ejecutó con éxito el método UpdateAsync desde el RepositoryBase para la entidad {entity}");
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método UpdateAsync desde el RepositoryBase para la entidad {entity}. Error: {ex}");
                throw;
            }
        }
        public virtual void HardDeleteAsync(T entity)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método HardDeleteAsync desde el RepositoryBase para la entidad {entity}");
            try
            {

                _context.Set<T>().Remove(entity);
                _logger.LogInfo(this.GetType().Name, $"Se ejecutó con éxito el método HardDeleteAsync desde el RepositoryBase para la entidad {entity}");
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método HardDeleteAsync desde el RepositoryBase para la entidad {entity}. Error: {ex}");
                throw;
            }
        }
        public virtual async Task SoftDeleteAsync<TId>(TId id) where TId : notnull
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método SoftDeleteAsync desde el RepositoryBase para el Id: {id}");
            try
            {
                var entity = await _context.Set<T>().FindAsync(new object[] { id });
                var property = typeof(T).GetProperty("Activo");

                if (entity != null && property != null && property.PropertyType == typeof(bool))
                {
                    property.SetValue(entity, false);
                    _context.Set<T>().Update(entity);
                }
                _logger.LogInfo(this.GetType().Name, $"Se ejecutó con éxito el método SoftDeleteAsync desde el RepositoryBase para el Id: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método SoftDeleteAsync desde el RepositoryBase para el Id: {id}. Error: {ex}");
                throw;
            }
        }

        public virtual async Task<T?> GetByIdAsync<TId>(TId id) where TId : notnull
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método GetByIdAsync desde el RepositoryBase para el Id: {id}");
            try
            {
                return await _context.Set<T>().FindAsync(new object[] { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método GetByIdAsync desde el RepositoryBase para el Id: {id}. Error: {ex}");
                throw;
            }
        }

    }
}