using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class UnidadMedidaRepository : EFRepository<UnidadMedida>, IUnidadMedidaRepository
    {

        public UnidadMedidaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
