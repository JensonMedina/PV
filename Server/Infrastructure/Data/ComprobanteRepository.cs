using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class ComprobanteRepository : EFRepository<Comprobante>, IComprobanteRepository
    {

        public ComprobanteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
