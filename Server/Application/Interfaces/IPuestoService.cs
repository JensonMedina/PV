using Application.Common;
using Application.Models.Request;
using Application.Models.Response;

namespace Application.Interfaces
{
    public interface IPuestoService
    {
        Task<PagedResponse<PuestoResponse>> GetAll(int negocioId, int pageNumber, int pageSize);
        Task<PuestoResponse?> GetById(int negocioId, int id);
        Task<PuestoResponse> Register(PuestoRequest request);
        Task<PuestoResponse> Modify(int id, PuestoModifyRequest request);
        Task Disable(int negocioId, int id);
    }
}
