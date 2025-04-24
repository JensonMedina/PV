using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class VentaDetalleRepository : EFRepository<VentaDetalle>, IVentaDetalleRepository
    {

        public VentaDetalleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
