using Application.Common;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProveedorService
    {  
        Task RegistrarProveedorAsync(ProveedorRequest proveedorRequest);

        Task<ProveedorResponse> ConsultarProveedorPorIdAsync(int id);

        Task<List<ProveedorResponse>> ConsultarProveedorPorNegocioAsync(string negocio);

        Task<List<ProveedorResponse>> ConsultarProveedorPorRubroAsync(string rubro);

        Task EliminarProveedorAsync(int id);

        Task ModificarProveedorAsync(int id, ProveedorRequest proveedorRequest); 
    }
}
