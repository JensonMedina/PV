using Application.Common;
using Application.Interfaces;
using Application.Mappings;
using Application.Models.Request;
using Domain.Entities;

namespace Application.Services
{
    public class NegocioService : INegocioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerApp _logger;
        private readonly IRubroService _rubroService;
        private readonly IPlanSaasService _planSaasService;
        private readonly IMedioPagoService _medioPagoService;
        public NegocioService(
         IUnitOfWork unitOfWork,
         ILoggerApp logger,
         IRubroService rubroService,
         IPlanSaasService planSaasService,
         IMedioPagoService medioPagoService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _rubroService = rubroService;
            _planSaasService = planSaasService;
            _medioPagoService = medioPagoService;
        }

        /// <summary>
        /// Método usado para registrar un negocio por primera vez
        /// </summary>
        /// <param name="newNegocio"></param>
        /// <returns></returns>
        public async Task Register(NegocioRequest newNegocio)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método Register. Se intenta registrar el negocio: {newNegocio.Nombre}");
            Negocio? negocio = null;
            try
            {
                #region Validar Rubro
                var rubro = await _rubroService.ValidarRubro(newNegocio.RubroId);
                #endregion

                #region Validar PlanSaas
                var plansaas = await _planSaasService.ValidarPlanSaas(newNegocio.PlanSaasId);
                #endregion

                #region mapeamos de Request a entidad
                try
                {
                    _logger.LogInfo(this.GetType().Name, $"Ejecutando método Register. Mapeando de NegocioRequest a Negocio");
                    negocio = NegocioMapping.ToEntity(newNegocio);
                }
                catch (Exception ex)
                {
                    _logger.LogError(this.GetType().Name, $"Ocurrió un error al intentar mapear de NegocioRequest a Negocio. Error: {ex.Message}");
                    throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
                }
                #endregion

                #region Invocamos al repositorio del Negocio
                await _unitOfWork.Negocios.Register(negocio);
                await _unitOfWork.CompleteAsync();
                _logger.LogInfo(this.GetType().Name, "Se terminó de ejecutar con éxito el método Register");
                #endregion

                #region Validar y registrar medio de pago
                await _medioPagoService.Register(newNegocio.MedioPagoRequest, negocio);
                #endregion
            }
            catch (Exception ex)
            {
                var errorDetails = $@"
                Ocurrió un error en el método: {this.GetType().Name} - Register
                Negocio: {newNegocio.Nombre}
                Mensaje de Error: {ex.Message}
                StackTrace: {ex.StackTrace}
                InnerException: {(ex.InnerException != null ? ex.InnerException.Message : "No hay InnerException")}
                ";
                _logger.LogError(this.GetType().Name, errorDetails);
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
    }
}
