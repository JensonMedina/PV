using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRubroService
    {
        Task<Rubro?> ValidateRubro(int id);
    }
}
