using Application.Interfaces;
using Application.Mappings;
using Application.Models.Request;
using Domain.Entities;

namespace Application.Services
{
    public class NegocioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerApp _logger;
        public NegocioService(IUnitOfWork unitOfWork, ILoggerApp logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public void Register(NegocioRequest newNegocio)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método Register. Se intenta registrar el negocio:{newNegocio.Nombre}");
            object negocio = null;
            try
            {
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

                _unitOfWork.Negocios.Register((Negocio)negocio);
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
