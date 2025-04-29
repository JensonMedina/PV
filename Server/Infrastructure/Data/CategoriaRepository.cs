using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class CategoriaRepository : EFRepository<Categoria>, ICategoriaRepository
    {

        public CategoriaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
