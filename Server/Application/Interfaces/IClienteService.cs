using Application.Common;
using Application.Models.Request;
using Application.Models.Response;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<Result<PagedResponse<ClienteResponse>>> GetClientesAsync(int pageNumber, int pageSize);
        Task<Result<ClienteResponse>> GetClienteByIdAsync(int id);
        Task<Result<ClienteResponse>> CreateClienteAsync(ClienteRequest request);
        Task<Result<ClienteResponse>> UpdateClienteAsync(int id, ClienteRequest request);
        Task<Result<string>> DeleteClienteAsync(int id);
    }
}
