using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Task<bool> ExistsByEmailAsync(string email);

    }
}
