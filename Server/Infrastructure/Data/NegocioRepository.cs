using Application.Interfaces;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class NegocioRepository : EFRepository<Negocio>, INegocioRepository
    {
        public NegocioRepository(ApplicationDbContext context, ILoggerApp logger) : base(context, logger)
        {

        }

        /// <summary>
        /// Método usado para registar en bd un negocio nuevo.
        /// </summary>
        /// <param name="newNegocio"></param>
        /// <returns></returns>
        public async Task Register(Negocio newNegocio)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método Register. Se intenta registrar el negocio:{newNegocio.Nombre}");
            try
            {
                _ = await _context.Negocios.AddAsync(newNegocio);
                _logger.LogInfo(this.GetType().Name, $"Se registró con exito en base de datos el negocio:{newNegocio.Nombre}");
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método Register al intentar registrar el negocio {newNegocio.Nombre}. Error: {ex.Message}");
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
        /// <summary>
        /// Método usado para buscar en base de datos algún negocio por tipo y nro de documento.
        /// </summary>
        /// <param name="tipoDocumento"></param>
        /// <param name="nroDocumento"></param>
        /// <returns></returns>
        public async Task<Negocio?> GetByNroDocumento(TipoDocumento tipoDocumento, string nroDocumento)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método GetByNroDocumento. Se busca en base de datos algún negocio con TipoDocumento: {tipoDocumento} y NumeroDocumento: {nroDocumento}");
            Negocio? negocio;
            try
            {
                negocio = await _context.Negocios.Where(n => n.TipoDocumento.Equals(tipoDocumento) && n.NumeroDocumento.Equals(nroDocumento)).FirstOrDefaultAsync();
                _logger.LogInfo(this.GetType().Name, "Se ejecutó con éxito el método GetByNroDocumento");
                return negocio;
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método GetByNroDocumento al intentar buscar un negocio con TipoDocumento: {tipoDocumento} y NumeroDocumento: {nroDocumento}. Error: {ex}");
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
        /// <summary>
        /// Método usado para buscar en base de datos un negocio a partir del email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Negocio?> GetByEmail(string email)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método GetByNroEmail. Se busca en base de datos algún negocio con Email: {email}.");
            Negocio? negocio;
            try
            {
                negocio = await _context.Negocios.Where(n => n.Email.Equals(email)).FirstOrDefaultAsync();
                _logger.LogInfo(this.GetType().Name, "Se ejecutó con éxito el método GetByNroEmail");
                return negocio;
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método GetByNroEmail al intentar buscar un negocio con Email: {email}. Error: {ex}");
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
    }
}
