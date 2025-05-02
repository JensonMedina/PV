using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        private readonly ApplicationDbContext _context;
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public async Task<bool> ExistsByEmailAsync(string email, int negocioId)
        {
            return await _context.Clientes.AsNoTracking().AnyAsync(c => c.Email == email && c.Activo && c.NegocioId == negocioId);
        }

        public async Task<(IEnumerable<Cliente> Items, int TotalCount)>
          GetPageByNegocioAsync(int negocioId, int pageNumber, int pageSize, bool onlyActive)
        {
            var query = _context.Clientes
                .AsNoTracking()
                .Where(c => c.NegocioId == negocioId && (!onlyActive || c.Activo));

            var total = await query.CountAsync();

            var items = await query
                .OrderBy(c => c.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return (items, total);
        }
    }
}
