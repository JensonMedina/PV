using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class NegocioRepository : EFRepository<Negocio>, INegocioRepository
    {

        public NegocioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
