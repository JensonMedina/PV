using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class ProductoNegocioRepository : EFRepository<ProductoNegocio>, IProductoNegocioRepository
    {

        public ProductoNegocioRepository(ApplicationDbContext context, ILoggerApp logger) : base(context, logger)
        {
        }
    }
}
