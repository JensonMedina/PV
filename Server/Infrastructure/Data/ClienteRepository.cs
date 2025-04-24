using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {

        public ClienteRepository(ApplicationDbContext context) : base(context){}

        public async Task<(IEnumerable<Cliente> Items, int TotalCount)> GetPageAsync(int pageNumber, int pageSize)
        {
            var query = _context.Set<Cliente>().Where(cl=>cl.Activo).AsNoTracking();

            //cuenta totoal de clientes activos
            var total = await query.CountAsync();

           // trae la pagina solicitada      
            var items =await query
                .Skip((pageNumber - 1 ) * pageSize)   // omite registros de paginas anteriores
                .Take(pageSize)                       // toma la cantidad de registros solicitados
                .ToListAsync(); 

            // devuelve la lista de clientes y el total de clientes activos
            return (items, total);
        
        
        }

    }
}
