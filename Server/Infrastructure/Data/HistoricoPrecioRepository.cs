using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class HistoricoPrecioRepository : EFRepository<HistoricoPrecio>, IHistoricoPrecioRepository
    {

        public HistoricoPrecioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
