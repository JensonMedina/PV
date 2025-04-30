using Application.Common;
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
            //_logger.LogInfo(this.GetType().Name, $"Ejecutando método GetByIp. Se busca en base de datos algún puesto con ip: {ip}");
            try
            {
                Puesto? puesto = await _context.Puestos.Where(p =>p.DireccionIP.Equals(ip)).FirstOrDefaultAsync();
                if (puesto is null)
                {
                    //_logger.LogInfo(this.GetType().Name, $"Puesto con dirección IP: {ip}, no encontrado.");
                    throw ExceptionApp.NotFound($"Puesto con dirección IP: {ip}, no encontrado.");
                }
                return puesto;
            }
            catch (Exception ex)
            {
                //_logger.LogError(this.GetType().Name, $"Ocurrió un error en el método GetByIp. Error: {ex.Message}");
                throw; 
            }
        }
        public async Task<Puesto?> GetByMac(string mac)
        {
            //_logger.LogInfo(this.GetType().Name, $"Ejecutando método GetByMac. Se busca en base de datos algún puesto con mac: {mac}");
            try
            {
                Puesto? puesto = await _context.Puestos.Where(p => p.DireccionMAC.Equals(mac)).FirstOrDefaultAsync();
                if (puesto is null)
                {
                    //_logger.LogInfo(this.GetType().Name, $"Puesto con dirección MAC: {mac}, no encontrado.");
                    throw ExceptionApp.NotFound($"Puesto con dirección MAC: {mac}, no encontrado.");
                }
                return puesto;
            }
            catch (Exception ex)
            {
                //_logger.LogError(this.GetType().Name, $"Ocurrió un error en el método GetByMac. Error: {ex.Message}");
                throw; 
            }
        }
        public async Task<Puesto?> GetById(int id, int negocioId)
        {
            //_logger.LogInfo(this.GetType().Name, $"Ejecutando método GetById. Se busca en base de datos algún puesto con Id: {id}");
            try
            {
                Puesto? puesto = await _context.Puestos.Where(p => p.NegocioId.Equals(negocioId) && p.Id.Equals(id)).FirstOrDefaultAsync();
                if(puesto == null)
                {
                    //_logger.LogError(this.GetType().Name, $"No existe un puesto donde coincidan el id del puesto: {id} y el id de negocio: {negocioId}.");
                    throw ExceptionApp.NotFound($"No existe un puesto donde coincidan el id del puesto: {id} y el id de negocio: {negocioId}.");
                }
                
                return puesto;
            }
            catch (Exception ex)
            {
                //_logger.LogError(this.GetType().Name, $"Ocurrió un error en el método GetById. Error: {ex.Message}");
                throw;
            }
        }
    }
}
