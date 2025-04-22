using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class VentaRepository : EFRepository<Venta>, IVentaRepository
    {

        public VentaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
