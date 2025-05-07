using Application.Interfaces;
using Application.Mappings;
using Application.Models.Request;
using Domain.Entities;

namespace Application.Services
{
    public class MedioPagoService : IMedioPagoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerApp _logger;
        public MedioPagoService(
         IUnitOfWork unitOfWork,
         ILoggerApp logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Método para registrar el medio de pago de un negocio
        /// </summary>
        public async Task Register(MedioPagoRequest newMedioPago, Negocio negocio)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método Register. Se intenta registrar el medio de pago del titular: {newMedioPago.NombreTitular}");
            MedioPago? medioPago = null;
            try
            {
                #region Validar datos cobro
                //agregar logica para validar datos como TokenProveedor, NombreTitular, TipoMedioPago, UltimosDigitos, FechaExpiracion
                #endregion

                #region Mapeamos de request a entidad
                try
                {
                    _logger.LogInfo(this.GetType().Name, $"Ejecutando método Register. Mapeando de MedioPagoRequest a MedioPago");
                    medioPago = MedioPagoMapping.ToEntity(newMedioPago, negocio);
                }
                catch (Exception ex)
                {
                    _logger.LogError(this.GetType().Name, $"Ocurrió un error al intentar mapear de MedioPagoRequest a MedioPago. Error: {ex.Message}");
                    throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
                }
                #endregion

                #region Registramos en bd
                await _unitOfWork.MedioPagos.AddAsync(medioPago);
                await _unitOfWork.CompleteAsync();
                #endregion
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método Register al intentar registrar el medio de pago del titular: {newMedioPago.NombreTitular}. Error: {ex.Message}");
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
    }
}
