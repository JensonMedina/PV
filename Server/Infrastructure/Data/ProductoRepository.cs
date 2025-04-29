using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class ProductoRepository : EFRepository<Producto>, IProductoRepository
    {

        public ProductoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
