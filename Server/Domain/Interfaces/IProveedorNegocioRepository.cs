using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProveedorNegocioRepository : IRepositoryBase<ProveedorNegocio>
    {
        Task<(IEnumerable<Proveedor> Items, int TotalCount)> GetPageByNegocioAsync(
    int negocioId, int pageNumber, int pageSize, bool onlyActive = true);
        Task<ProveedorNegocio?> GetByIdsAsync(int proveedorId, int negocioId);

    }
}
