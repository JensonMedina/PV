using Domain.Entities;
using Domain.Enum;

namespace Domain.Interfaces
{
    public interface INegocioRepository : IRepositoryBase<Negocio>
    {
        Task Register(Negocio newNegocio);
        Task<Negocio?> GetByNroDocumento(TipoDocumento tipoDocumento, string nroDocumento);
        Task<Negocio?> GetByEmail(string email);
    }
}
