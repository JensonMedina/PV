using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class HistoricoPrecioRepository : EFRepository<HistoricoPrecio>, IHistoricoPrecioRepository
    {

        public HistoricoPrecioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
