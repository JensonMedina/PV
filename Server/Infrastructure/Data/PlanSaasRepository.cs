using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class PlanSaasRepository : EFRepository<PlanSaas>, IPlanSaasRepository
    {

        public PlanSaasRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
