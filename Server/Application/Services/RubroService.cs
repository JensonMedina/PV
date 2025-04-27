using Application.Common;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class RubroService : IRubroService
    {
        private readonly ILoggerApp _logger;
        private readonly IUnitOfWork _unitOfWork;
        public RubroService(ILoggerApp logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<Rubro?> ValidarRubro(int id)
        {
            _logger.LogInfo(this.GetType().Name, "Ejecutando método ValidarRubro");
            try
            {
                _logger.LogInfo(this.GetType().Name, $"Validando que existe el Rubro con id: {id}");
                var rubro = await _unitOfWork.Rubros.GetByIdAsync(id);
                if (rubro is null)
                {
                    _logger.LogInfo(this.GetType().Name, $"No se encontró el Rubro con id: {id}");
                    throw ExceptionApp.NotFound($"Rubro con id: {id} no encontrado.");
                }
                _logger.LogInfo(this.GetType().Name, $"Se encontró con éxito el Rubro con id: {id} - Rubro: {rubro.Nombre}");
                return rubro;
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método ValidarRubro al validar si existe el Rubro con id {id}. Error: {ex.Message}");
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
    }
}
