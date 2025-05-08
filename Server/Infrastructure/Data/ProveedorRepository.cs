using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProveedorRepository : EFRepository<Proveedor>, IProveedorRepository
    {

        public ProveedorRepository(ApplicationDbContext context, ILoggerApp logger) : base(context, logger)
        { 
            
        }


        public async Task<(IEnumerable<Proveedor> Items, int TotalCount)> GetPageByRubroAsync(int rubroId, int pageNumber, int pageSize, bool onlyActive = true)
        {
            IQueryable<Proveedor> query = _context.Proveedores.AsNoTracking();
            query = query.Where(p => p.RubroId == rubroId);

            if (onlyActive)
            {
                query = query.Where(p => p.Activo);
            }
            var total = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, total);
        }
        public async Task<Proveedor?> GetByNumeroDocumentoAsync(string numeroDocumento)
        {
            return await _context.Proveedores
                .FirstOrDefaultAsync(p => p.NumeroDocumento == numeroDocumento);
        }

        public async Task<Proveedor?> GetByEmailAsync(string email)
        {
            return await _context.Proveedores
                .FirstOrDefaultAsync(p => p.Email == email);
        }

    }
}

