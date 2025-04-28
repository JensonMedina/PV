using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRubroService
    {
        Task<Rubro?> ValidarRubro(int id);
    }
}
