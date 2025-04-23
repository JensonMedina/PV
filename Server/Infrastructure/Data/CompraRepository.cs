using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class CompraRepository : EFRepository<Compra>, ICompraRepository
    {

        public CompraRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
