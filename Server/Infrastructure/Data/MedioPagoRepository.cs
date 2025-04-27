using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class MedioPagoRepository : EFRepository<MedioPago>, IMedioPagoRepository
    {
        private readonly ILoggerApp _logger;
        public MedioPagoRepository(ApplicationDbContext context, ILoggerApp logger) : base(context)
        {
            _logger = logger;
        }
        public async Task RegisterAsync(MedioPago newMedioPago)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método Register. Se intenta registrar el medio de pago del titular: {newMedioPago.NombreTitular}");
            try
            {
                await _context.MediosPagos.AddAsync(newMedioPago);
                _logger.LogInfo(this.GetType().Name, $"Se registró con exito en base de datos el medio de pago del titular: {newMedioPago.NombreTitular}");
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método Register al intentar registrar el medio de pago del titular: {newMedioPago.NombreTitular}. Error: {ex.Message}");
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
    }
}
