using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProveedorService
    {
        Task RegistrarProveedorAsync(Proveedor proveedor); // desde unitofwork con base
        Task<Proveedor?> ConsultarProveedorPorIdAsync(int id); // desde unitofwork con base
        Task<List<Proveedor>> ConsultarProveedorPorNegocioAsync(string negocio); // desde unitofwork con proveedor
        Task<List<Proveedor>> ConsultarProveedorPorRubroAsync(string rubro); // desde unitofwork con proveedor
        Task EliminarProveedorAsync(int id); // desde unitofwork con base
        Task ModificarProveedorAsync(int id, Proveedor proveedor); // desde unitofwork con base
    }
}
