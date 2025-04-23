using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {

        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
