using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class NegocioRepository : EFRepository<Negocio>, INegocioRepository
    {
        private readonly ILoggerApp _logger;
        public NegocioRepository(ApplicationDbContext context, ILoggerApp logger) : base(context)
        {
            _logger = logger;
        }

        /// <summary>
        /// Método usado para registar en bd un negocio nuevo
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
    }
}
