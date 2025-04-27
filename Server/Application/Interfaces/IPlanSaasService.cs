using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPlanSaasService
    {
        Task<PlanSaas?> ValidarPlanSaas(int id);
    }
}
