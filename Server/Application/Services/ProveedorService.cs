using Application.Common;
using Application.Interfaces;
using Application.Mappings;
using Application.Models.Request;
using Application.Models.Response;

namespace Application.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerApp _loggerApp;

        public ProveedorService(IUnitOfWork unitOfWork, ILoggerApp loggerApp)
        {
            _unitOfWork = unitOfWork;
            _loggerApp = loggerApp;
        }
        public async Task RegistrarProveedorAsync(ProveedorRequest newProveedor)
        {
            string contexto = $"{this.GetType().Name} - {nameof(RegistrarProveedorAsync)}";

            try
            {
                _loggerApp.LogInfo(contexto, "Iniciando registro de nuevo proveedor", $"NegocioId: {newProveedor.NegocioId}, RubroId: {newProveedor.RubroId}");

                #region Validar Negocio
                _loggerApp.LogInfo(contexto, "Iniciando validación de negocio", $"NegocioId: {newProveedor.NegocioId}");
                var negocio = await _unitOfWork.Negocios.GetByIdAsync(newProveedor.NegocioId);
                if (negocio == null)
                {
                    _loggerApp.LogError(contexto, "Negocio no encontrado", $"NegocioId: {newProveedor.NegocioId}");
                    throw ExceptionApp.NotFound($"El negocio con id: {newProveedor.NegocioId} no existe");
                }
                _loggerApp.LogInfo(contexto, "Negocio encontrado", $"NegocioId: {negocio.Id}");
                #endregion


                #region Validar Rubro
                _loggerApp.LogInfo(contexto, "Iniciando validación de rubro", $"RubroId: {newProveedor.RubroId}");
                var rubro = await _unitOfWork.Rubros.GetByIdAsync(newProveedor.RubroId);
                if (rubro == null)
                {
                    _loggerApp.LogError(contexto, "Rubro no encontrado", $"RubroId: {newProveedor.RubroId}");
                    throw ExceptionApp.NotFound($"El rubro con id: {newProveedor.RubroId} no existe");
                }
                _loggerApp.LogInfo(contexto, "Rubro encontrado", $"RubroId: {rubro.Id}");
                #endregion
                var proveedor = ProveedorMapping.ToEntity(newProveedor);

                await _unitOfWork.Proveedores.AddAsync(proveedor);
                await _unitOfWork.CompleteAsync();

                _loggerApp.LogInfo(contexto, "Proveedor registrado exitosamente", $"ProveedorId: {proveedor.Id}");
            }
            catch (Exception ex)
            {
                _loggerApp.LogError(contexto, "Error inesperado en el registro de proveedor", ex.ToString());
                throw;
            }
        }


        public Task<ProveedorResponse> ConsultarProveedorPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProveedorResponse>> ConsultarProveedorPorNegocioAsync(string negocio)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProveedorResponse>> ConsultarProveedorPorRubroAsync(string rubro)
        {
            throw new NotImplementedException();
        }

        public Task EliminarProveedorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task ModificarProveedorAsync(int id, ProveedorRequest proveedorRequest)
        {
            throw new NotImplementedException();
        }





    }
}
