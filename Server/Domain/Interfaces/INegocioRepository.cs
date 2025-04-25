using Domain.Entities;

namespace Domain.Interfaces
{
    public interface INegocioRepository : IRepositoryBase<Negocio>
    {
        Task Register(Negocio newNegocio);
    }
}
