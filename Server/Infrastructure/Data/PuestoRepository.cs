using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PuestoRepository : EFRepository<Puesto>, IPuestoRepository
    {
        public ApplicationDbContext _context;
        public PuestoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<ICollection<Puesto>> GetByNegocioId(int negocioId)
        {
            return await _context.Puestos.Where(e => e.NegocioId == negocioId).ToListAsync();
        }
    }
}
