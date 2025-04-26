using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class ProveedorRepository : EFRepository<Proveedor>, IProveedorRepository
    {

        public ProveedorRepository(ApplicationDbContext context) : base(context)
        { }
            public Task<List<Proveedor>> GetByNegocioAsync(string nombreNegocio)
            {
                // implementación pendiente
                throw new NotImplementedException();
            }

            public Task<List<Proveedor>> GetByRubroAsync(string rubro)
            {
                // implementación pendiente
                throw new NotImplementedException();
            }
    }
}

