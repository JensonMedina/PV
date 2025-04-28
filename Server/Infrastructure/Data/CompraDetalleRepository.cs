using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class CompraDetalleRepository : EFRepository<CompraDetalle>, ICompraDetalleRepository
    {

        public CompraDetalleRepository(ApplicationDbContext context, ILoggerApp logger) : base(context, logger)
        {
        }
    }
}
