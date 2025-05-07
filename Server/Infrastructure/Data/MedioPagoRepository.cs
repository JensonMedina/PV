using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class MedioPagoRepository : EFRepository<MedioPago>, IMedioPagoRepository
    {
        public MedioPagoRepository(ApplicationDbContext context, ILoggerApp logger) : base(context, logger)
        {
            
        }
    }
}
