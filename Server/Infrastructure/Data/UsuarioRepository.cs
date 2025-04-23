using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class UsuarioRepository : EFRepository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
