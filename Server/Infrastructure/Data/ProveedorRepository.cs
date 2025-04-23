using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProveedorRepository : EFRepository<Proveedor>, IProveedorRepository
    {

        public ProveedorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
