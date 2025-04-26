using Application.Interfaces;
using Application.Mappings;
using Application.Models.Request;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class NegocioService : INegocioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerApp _logger;
        public NegocioService(IUnitOfWork unitOfWork, ILoggerApp logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task Register(NegocioRequest newNegocio)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método Register. Se intenta registrar el negocio:{newNegocio.Nombre}");
            object? negocio = null;
            try
            {
                #region Validar Rubro
                //cuando este hecho el repositorio de Rubro
                #endregion

                #region Validar PlanSaas
                try
                {
                    _logger.LogInfo(this.GetType().Name, $"Validando que existe el PlanSaas con id: {newNegocio.IdPlanSaas}");
                    var plansass = await _unitOfWork.PlanesSaas.GetByIdAsync(newNegocio.IdPlanSaas);
                    if (plansass is null)
                    {
                        _logger.LogInfo(this.GetType().Name, $"No se encontró el PlanSaas con id: {newNegocio.IdPlanSaas}");
                        throw new Exception();
                    }
                    _logger.LogInfo(this.GetType().Name, $"Se encontró con éxito el PlanSaas con id: {newNegocio.IdPlanSaas} - Plan: {plansass.Nombre}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método Register al validar si existe el PlanSaas con id {newNegocio.IdPlanSaas}. Error: {ex.Message}");
                    throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
                }
                #endregion

                #region Validar Datos de cobro
                //Cuando este realizada la lógica
                #endregion

                #region Registrar en bd los datos de cobro
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

                await _unitOfWork.Negocios.Register((Negocio)negocio);
                await _unitOfWork.CompleteAsync();
                _logger.LogInfo(this.GetType().Name, "Se terminó de ejecutar con éxito el método Register");
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método Register al intentar registrar el negocio {newNegocio.Nombre}. Error: {ex.Message}");
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
    }
}
