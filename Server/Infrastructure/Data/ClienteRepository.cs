using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        private readonly ILoggerApp _logger;
        public ClienteRepository(ApplicationDbContext context, ILoggerApp logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<bool> NumeroDocumentoExist(string numeroDocumento, int negocioId)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método NumeroDocumentoExist");
            try
            {
                bool existe = await _context.Clientes.AnyAsync(c => c.NumeroDocumento == numeroDocumento && c.Activo && c.NegocioId == negocioId);
                return existe;
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error inesperado en el método NumeroDocumentoExist. Error: {ex}");
                throw;
            }

        }
        public async Task<Cliente?> GetByEmail(string email, int negocioId)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método GetByEmail");
            try
            {
                Cliente? cliente = await _context.Clientes.Where(c => c.Email == email && c.Activo && c.NegocioId == negocioId).FirstOrDefaultAsync();
                return cliente;
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error inesperado en el método GetByEmail. Error: {ex}");
                throw;
            }
        }
    }
}
