using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class HistoricoStockRepository : EFRepository<HistoricoStock>, IHistoricoStockRepository
    {

        public HistoricoStockRepository(ApplicationDbContext context, ILoggerApp logger) : base(context, logger)
        {
        }
    }
}
