using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProveedorRepository : IRepositoryBase<Proveedor>
    {
        Task<(IEnumerable<Proveedor> Items, int TotalCount)> GetPageByRubroAsync(int rubroId, int pageNumber, int pageSize, bool onlyActive = true);
        Task<Proveedor?> GetByNumeroDocumentoAsync(string numeroDocumento);

    }
}
