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
        public async Task Register(ProveedorRequest newProveedor)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Register)}";

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
        public async Task<PagedResponse<ProveedorResponse>> GetByNegocio(int pageNumber, int pageSize, bool onlyActive = true, int negocioId = 0)
        {
            string contexto = $"{this.GetType().Name} - {nameof(GetByNegocio)}";
            try
            {
                _loggerApp.LogInfo(contexto, "Iniciando obtención de proveedores por negocio",
                    $"NegocioId: {negocioId}, PageNumber: {pageNumber}, PageSize: {pageSize}, OnlyActive: {onlyActive}");

                #region Validar Negocio

                _loggerApp.LogInfo(contexto, "Iniciando validación de negocio", $"NegocioId: {negocioId}");
                var negocio = await _unitOfWork.Negocios.GetByIdAsync(negocioId);
                if (negocio == null)
                {
                    _loggerApp.LogError(contexto, "Negocio no encontrado", $"NegocioId: {negocioId}");
                    throw ExceptionApp.NotFound($"El negocio con id: {negocioId} no existe");
                }
                _loggerApp.LogInfo(contexto, "Negocio encontrado", $"NegocioId: {negocio.Id}");
                #endregion
                _loggerApp.LogInfo(contexto,
                    $"Obteniendo página {pageNumber} (size={pageSize}, onlyActive={onlyActive}) para negocio {negocioId}");
                var (entidades, totalItems) = await _unitOfWork.Proveedores.GetPageAsync(negocioId, pageNumber, pageSize, onlyActive: true);
                var proveedoresResponse = entidades.Select(ProveedorMapping.ToResponse).ToList();
                var pagedResponse = new PagedResponse<ProveedorResponse>(proveedoresResponse, totalItems, pageNumber, pageSize);
                _loggerApp.LogInfo(contexto,
                    $"Página {pageNumber} obtenida con éxito. Total registros: {totalItems} para negocio {negocioId}");

                return pagedResponse;
            }
            catch (Exception ex)
            {
                _loggerApp.LogError(contexto, "Error inesperado en la obtención de proveedores por negocio", ex.ToString());
                throw;
            }
        }

        public async Task<PagedResponse<ProveedorResponse>> GetByRubro(int pageNumber, int pageSize, bool onlyActive, int rubroId)
        {
            string contexto = $"{this.GetType().Name} - {nameof(GetByRubro)}";
            try
            {
                _loggerApp.LogInfo(contexto, "Iniciando obtención de proveedores por rubro",
                    $"RubroId: {rubroId}, PageNumber: {pageNumber}, PageSize: {pageSize}, OnlyActive: {onlyActive}");

                // Añadir log para verificar el valor de onlyActive
                _loggerApp.LogInfo(contexto, $"Valor de onlyActive recibido: {onlyActive}");

                #region Validar Rubro
                _loggerApp.LogInfo(contexto, "Iniciando validación de rubro", $"RubroId: {rubroId}");
                var rubro = await _unitOfWork.Rubros.GetByIdAsync(rubroId);
                if (rubro == null)
                {
                    _loggerApp.LogError(contexto, "Rubro no encontrado", $"RubroId: {rubroId}");
                    throw ExceptionApp.NotFound($"El rubro con id: {rubroId} no existe");
                }
                _loggerApp.LogInfo(contexto, "Rubro encontrado", $"RubroId: {rubro.Id}");
                #endregion

                _loggerApp.LogInfo(contexto,
                   $"Obteniendo página {pageNumber} (size={pageSize}, onlyActive={onlyActive}) para rubro {rubroId}");

                // Asegurarse de pasar explícitamente el parámetro onlyActive
                var (entidades, totalItems) = await _unitOfWork.Proveedores.GetPageByRubroAsync(
                    rubroId,
                    pageNumber,
                    pageSize,
                    onlyActive: onlyActive); // Parámetro explícito

                var proveedoresResponse = entidades.Select(ProveedorMapping.ToResponse).ToList();
                var pagedResponse = new PagedResponse<ProveedorResponse>(proveedoresResponse, totalItems, pageNumber, pageSize);

                _loggerApp.LogInfo(contexto,
                    $"Página {pageNumber} obtenida con éxito. Total registros: {totalItems} para rubro {rubroId}");

                return pagedResponse;
            }
            catch (Exception ex)
            {
                _loggerApp.LogError(contexto, "Error inesperado en la obtención de proveedores por rubro", ex.ToString());
                throw;
            }
        }
        public async Task Disable(int idNegocio, int idProveedor)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Disable)}";
            try
            {
                _loggerApp.LogInfo(contexto, "Iniciando desactivación de proveedor",
                    $"NegocioId: {idNegocio}, ProveedorId: {idProveedor}");

                #region Validar Negocio
                _loggerApp.LogInfo(contexto, "Iniciando validación de negocio", $"NegocioId: {idNegocio}");
                var negocio = await _unitOfWork.Negocios.GetByIdAsync(idNegocio);
                if (negocio == null)
                {
                    _loggerApp.LogError(contexto, "Negocio no encontrado", $"NegocioId: {idNegocio}");
                    throw ExceptionApp.NotFound($"El negocio con id: {idNegocio} no existe");
                }
                _loggerApp.LogInfo(contexto, "Negocio encontrado", $"NegocioId: {negocio.Id}");
                #endregion

                #region Validar Proveedor
                _loggerApp.LogInfo(contexto, "Iniciando validación de proveedor", $"ProveedorId: {idProveedor}");
                var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(idProveedor);

                if (proveedor == null)
                {
                    _loggerApp.LogError(contexto, "Proveedor no encontrado", $"ProveedorId: {idProveedor}");
                    throw ExceptionApp.NotFound($"El proveedor con id: {idProveedor} no existe");
                }

                if (proveedor.NegocioId != idNegocio)
                {
                    _loggerApp.LogError(contexto, "El proveedor no pertenece al negocio especificado",
                        $"ProveedorId: {idProveedor}, NegocioId: {idNegocio}, ProveedorNegocioId: {proveedor.NegocioId}");
                    throw ExceptionApp.BadRequest($"El proveedor con id: {idProveedor} no pertenece al negocio con id: {idNegocio}");
                }

                if (!proveedor.Activo)
                {
                    _loggerApp.LogInfo(contexto, "El proveedor ya está desactivado", $"ProveedorId: {idProveedor}");
                    return;
                }
                #endregion

                // Desactivar proveedor
                proveedor.Activo = false;
                _unitOfWork.Proveedores.UpdateAsync(proveedor);
                await _unitOfWork.CompleteAsync();

                _loggerApp.LogInfo(contexto, "Proveedor desactivado exitosamente", $"ProveedorId: {idProveedor}");
            }
            catch (Exception ex)
            {
                _loggerApp.LogError(contexto, "Error inesperado en la desactivación de proveedor", ex.ToString());
                throw;
            }
        }

        public async Task Modify(int proveedorId, ProveedorModifiedRequest proveedorModifiedRequest)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Modify)}";
            try
            {
                _loggerApp.LogInfo(contexto, "Iniciando modificación de proveedor",
                    $"ProveedorId: {proveedorId}, RubroId: {proveedorModifiedRequest.RubroId}");


                #region Validar Rubro
                _loggerApp.LogInfo(contexto, "Iniciando validación de rubro", $"RubroId: {proveedorModifiedRequest.RubroId}");
                var rubro = await _unitOfWork.Rubros.GetByIdAsync(proveedorModifiedRequest.RubroId);
                if (rubro == null)
                {
                    _loggerApp.LogError(contexto, "Rubro no encontrado", $"RubroId: {proveedorModifiedRequest.RubroId}");
                    throw ExceptionApp.NotFound($"El rubro con id: {proveedorModifiedRequest.RubroId} no existe");
                }
                _loggerApp.LogInfo(contexto, "Rubro encontrado", $"RubroId: {rubro.Id}");
                #endregion

                #region Validar Proveedor
                _loggerApp.LogInfo(contexto, "Iniciando validación de proveedor", $"ProveedorId: {proveedorId}");
                var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(proveedorId);

                if (proveedor == null)
                {
                    _loggerApp.LogError(contexto, "Proveedor no encontrado", $"ProveedorId: {proveedorId}");
                    throw ExceptionApp.NotFound($"El proveedor con id: {proveedorId} no existe");
                }

                #endregion

                #region Mapeamos de modify a entidad

                _loggerApp.LogInfo(contexto, "Mapeando entidad");
                proveedor = ProveedorMapping.ModifiedToEntity(proveedorModifiedRequest, proveedor);

                #endregion
                _unitOfWork.Proveedores.UpdateAsync(proveedor);
                await _unitOfWork.CompleteAsync();

                _loggerApp.LogInfo(contexto, "Proveedor modificado exitosamente", $"ProveedorId: {proveedor.Id}");
            }
            catch (Exception ex)
            {
                _loggerApp.LogError(contexto, "Error inesperado en la modificación de proveedor", ex.ToString());
                throw;
            }
        }



    }
}
