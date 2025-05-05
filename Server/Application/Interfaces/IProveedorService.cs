using Application.Common;
using Application.Models.Request;
using Application.Models.Response;

namespace Application.Interfaces
{
    public interface IProveedorService
    {  
        Task Register(ProveedorRequest proveedorRequest, int negocioId);

        Task<PagedResponse<ProveedorResponse>> GetByNegocio(int pageNumber, int pageSize, bool onlyActive = true, int negocioId = 0);

        Task<PagedResponse<ProveedorResponse>> GetByRubro(int pageNumber, int pageSize, bool onlyActive = true, int rubroId = 0);

        Task Disable(int idNegocio, int idProveedor);

        Task Modify(int negocioId,int proveedorId, ProveedorModifiedRequest proveedorModifiedRequest); 
    }
}
