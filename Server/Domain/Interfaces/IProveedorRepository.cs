using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProveedorRepository : IRepositoryBase<Proveedor>
    {
        Task<List<Proveedor>> GetByNegocioAsync(string nombreNegocio);
        Task<List<Proveedor>> GetByRubroAsync(string rubro);
    }
}
