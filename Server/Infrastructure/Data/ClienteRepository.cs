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
        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Clientes.AsNoTracking().AnyAsync(c => c.Email == email && c.Activo);
        }



    }
}
