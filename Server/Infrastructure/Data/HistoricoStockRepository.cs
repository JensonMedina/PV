using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class HistoricoStockRepository : EFRepository<HistoricoStock>, IHistoricoStockRepository
    {

        public HistoricoStockRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
