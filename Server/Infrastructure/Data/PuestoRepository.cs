using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PuestoRepository : EFRepository<Puesto>, IPuestoRepository
    {
        public ApplicationDbContext _context;
        public PuestoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Puesto?> GetByIp(string ip)
        {
            return await _context.Puestos.Where(p => p.DireccionIP == ip).FirstOrDefaultAsync();
        }
        public async Task<Puesto?> GetByMac(string mac)
        {
            return await _context.Puestos.Where(p => p.DireccionMAC == mac).FirstOrDefaultAsync();
        }
        public async Task<Puesto?> GetById(int id, int negocioId)
        {
            Puesto? puesto = await _context.Puestos.Where(p => p.NegocioId.Equals(negocioId) && p.Id.Equals(id)).FirstOrDefaultAsync();
            return puesto;
        }
    }
}
