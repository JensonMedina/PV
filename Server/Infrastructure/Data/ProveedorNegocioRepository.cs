using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProveedorNegocioRepository : EFRepository<ProveedorNegocio>, IProveedorNegocioRepository
    {
        public ProveedorNegocioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<(IEnumerable<Proveedor> Items, int TotalCount)> GetPageByNegocioAsync(
    int negocioId, int pageNumber, int pageSize, bool onlyActive = true)
        {
            var query = _context.Set<ProveedorNegocio>()
                .AsNoTracking()
                .Include(pn => pn.Proveedor)
                .Where(pn => pn.NegocioId == negocioId);

            if (onlyActive)
            {
                query = query.Where(pn => pn.Proveedor.Activo);
            }
            var total = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(pn => pn.Proveedor)
                .ToListAsync();

            return (items, total);
        }
        public async Task<ProveedorNegocio?> GetByIdsAsync(int proveedorId, int negocioId)
        {
            return await _context.Set<ProveedorNegocio>()
                .AsNoTracking()
                .FirstOrDefaultAsync(pn => pn.ProveedorId == proveedorId && pn.NegocioId == negocioId);
        }


    }
}
