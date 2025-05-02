using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Task<bool> ExistsByEmailAsync(string email, int negocioId);
        Task<(IEnumerable<Cliente> Items, int TotalCount)> GetPageByNegocioAsync(int negocioId, int pageNumber, int pageSize, bool onlyActive);

    }
}
