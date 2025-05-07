using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Task<Cliente?> GetByEmail(string email, int negocioId);
        Task<Cliente?> NumeroDocumentoExist(string numeroDocumento, int negocioId);
    }
}
