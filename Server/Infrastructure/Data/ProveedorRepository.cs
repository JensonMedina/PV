using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class ProveedorRepository : EFRepository<Proveedor>, IProveedorRepository
    {

        public ProveedorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
