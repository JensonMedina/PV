using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class VentaRepository : EFRepository<Venta>, IVentaRepository
    {

        public VentaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
