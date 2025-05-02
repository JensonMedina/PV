using Application.Common;
using Application.Models.Request;
using Application.Models.Response;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<PagedResponse<ClienteResponse>> GetClientesAsync(int pageNumber, int pageSize, bool onlyActive = true, int NegocioId = 0);
        Task<ClienteResponse> GetClienteByIdAsync(int id);
        Task CreateClienteAsync(ClienteRequest request);
        Task UpdateClienteAsync(int id, ClienteRequest request);
        Task DeleteClienteAsync(int id, int negocioId);
    }
}
