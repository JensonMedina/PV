using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class NegocioRepository : EFRepository<Negocio>, INegocioRepository
    {

        public NegocioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
