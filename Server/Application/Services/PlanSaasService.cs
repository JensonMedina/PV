using Application.Common;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class PlanSaasService : IPlanSaasService
    {
        private readonly ILoggerApp _logger;
        private readonly IUnitOfWork _unitOfWork;
        public PlanSaasService(ILoggerApp logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Método para encontrar un plan saas a partir de un id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PlanSaas?> ValidatePlanSaas(int id)
        {
            _logger.LogInfo(this.GetType().Name, "Ejecutando método ValidarPlanSaas");
            try
            {
                _logger.LogInfo(this.GetType().Name, $"Validando que existe el PlanSaas con id: {id}");
                var plansass = await _unitOfWork.PlanesSaas.GetByIdAsync(id);
                if (plansass is null)
                {
                    _logger.LogInfo(this.GetType().Name, $"No se encontró el PlanSaas con id: {id}");
                    throw ExceptionApp.NotFound($"PlanSaas con id: {id} no encontrado.");
                }
                _logger.LogInfo(this.GetType().Name, $"Se encontró con éxito el PlanSaas con id: {id} - Plan: {plansass.Nombre}");
                return plansass;
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método ValidarPlanSaas al validar si existe el PlanSaas con id {id}. Error: {ex.Message}");
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
    }
}
