using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class UsuarioPuestoRepository : EFRepository<UsuarioPuesto>, IUsuarioPuestoRepository
    {

        public UsuarioPuestoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
