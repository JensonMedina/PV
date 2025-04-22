using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductoRepository : EFRepository<Producto>, IProductoRepository
    {

        public ProductoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
