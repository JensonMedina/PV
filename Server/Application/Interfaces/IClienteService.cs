using Application.Common;
using Application.Models.Request;
using Application.Models.Response;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<PagedResponse<ClienteResponse>> GetAll(int pageNumber, int pageSize, bool onlyActive = true, int NegocioId = 0);
        Task<ClienteResponse> GetById(int id);
        Task Register(ClienteRequest request);
        Task Modify(int id, ClienteModifyRequest request);
        Task Disable(int id, int negocioId);
    }
}
