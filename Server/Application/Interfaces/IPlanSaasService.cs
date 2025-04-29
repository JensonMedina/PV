using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPlanSaasService
    {
        Task<PlanSaas?> ValidatePlanSaas(int id);
    }
}
