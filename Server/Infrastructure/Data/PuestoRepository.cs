using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class PuestoRepository : EFRepository<Puesto>, IPuestoRepository
    {

        public PuestoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
