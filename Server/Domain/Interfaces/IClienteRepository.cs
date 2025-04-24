using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Task<(IEnumerable<Cliente> Items, int TotalCount)> GetPageAsync(int pageNumber, int pageSize);
    }
}
