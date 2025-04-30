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
        //Para que esta este metodo si no se usa ???
        public async Task<ICollection<Puesto>> GetByNegocioId(int negocioId)
        {
            return await _context.Puestos.Where(e => e.NegocioId == negocioId).ToListAsync();
        }
        public async Task<Puesto?> GetByIp(string ip, int negocioId)
        {
            //_logger.LogInfo(this.GetType().Name, $"Ejecutando método GetByIp. Se busca en base de datos algún puesto con ip: {ip}");
            try
            {
                Puesto? puesto = await _context.Puestos.Where(p => p.NegocioId.Equals(negocioId) && p.DireccionIP.Equals(ip)).FirstOrDefaultAsync();
                return puesto;
            }
            catch (Exception ex)
            {
                //_logger.LogError(this.GetType().Name, $"Ocurrió un error en el método GetByIp. Error: {ex.Message}");
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
        public async Task<Puesto?> GetByMac(string mac, int negocioId) //capaz que no hace falta preguntar por el negocio aca, ya que en teoria la mac es unica para pc, investigar.
        {
            //_logger.LogInfo(this.GetType().Name, $"Ejecutando método GetByMac. Se busca en base de datos algún puesto con mac: {ip}");
            try
            {
                Puesto? puesto = await _context.Puestos.Where(p => p.NegocioId.Equals(negocioId) && p.DireccionMAC.Equals(mac)).FirstOrDefaultAsync();
                return puesto;
            }
            catch (Exception ex)
            {
                //_logger.LogError(this.GetType().Name, $"Ocurrió un error en el método GetByMac. Error: {ex.Message}");
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
        public async Task<Puesto?> GetById(int id, int negocioId)
        {
            //_logger.LogInfo(this.GetType().Name, $"Ejecutando método GetById. Se busca en base de datos algún puesto con Id: {ip}");
            try
            {
                Puesto? puesto = await _context.Puestos.Where(p => p.NegocioId.Equals(negocioId) && p.Id.Equals(id)).FirstOrDefaultAsync();
                return puesto;
            }
            catch (Exception ex)
            {
                //_logger.LogError(this.GetType().Name, $"Ocurrió un error en el método GetById. Error: {ex.Message}");
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
    }
}
