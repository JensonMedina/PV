using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class ProductoNegocioRepository : EFRepository<ProductoNegocio>, IProductoNegocioRepository
    {

        public ProductoNegocioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
