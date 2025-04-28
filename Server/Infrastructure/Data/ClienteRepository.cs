using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {

        public ClienteRepository(ApplicationDbContext context, ILoggerApp logger) : base(context, logger)
        {
        }
    }
}
