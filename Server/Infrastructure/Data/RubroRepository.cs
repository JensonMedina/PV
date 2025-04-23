using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class RubroRepository : EFRepository<Rubro>, IRubroRepository
    {

        public RubroRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
