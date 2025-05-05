using Application.Common;
using Application.Interfaces;
using Application.Mappings;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

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
        public async Task Register(ProveedorRequest newProveedor, int negocioId)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Register)}";

            try
            {
                _loggerApp.LogInfo(contexto, "Iniciando registro de nuevo proveedor", $"NegocioId: {negocioId}, RubroId: {newProveedor.RubroId}");

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
                var proveedorNegocio = new ProveedorNegocio
                {
                    ProveedorId = proveedor.Id,
                    NegocioId = negocioId
                };
                await _unitOfWork.ProveedoresNegocio.AddAsync(proveedorNegocio);              
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
                var (entidades, totalItems) = await _unitOfWork.ProveedoresNegocio.GetPageByNegocioAsync(negocioId, pageNumber, pageSize, onlyActive: onlyActive);

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
                _loggerApp.LogInfo(contexto, "Iniciando desactivación de proveedor del negocio",
                    $"NegocioId: {idNegocio}, ProveedorId: {idProveedor}");

                #region Validar Negocio
                _loggerApp.LogInfo(contexto, "Iniciando validación de negocio", $"NegocioId: {idNegocio}");
                var negocio = await _unitOfWork.Negocios.GetByIdAsync(idNegocio);
                if (negocio == null)
                {
                    _loggerApp.LogError(contexto, "Negocio no encontrado", $"NegocioId: {idNegocio}");
                    throw ExceptionApp.NotFound($"El negocio con id: {idNegocio} no existe");
                }
                #endregion

                #region Validar Relación Proveedor-Negocio
                _loggerApp.LogInfo(contexto, "Buscando relación proveedor-negocio",
                    $"NegocioId: {idNegocio}, ProveedorId: {idProveedor}");

                var proveedorNegocio = await _unitOfWork.ProveedoresNegocio.GetByIdsAsync(idProveedor, idNegocio);
                if (proveedorNegocio == null)
                {
                    _loggerApp.LogError(contexto, "Relación proveedor-negocio no encontrada",
                        $"NegocioId: {idNegocio}, ProveedorId: {idProveedor}");
                    throw ExceptionApp.NotFound($"El proveedor con id: {idProveedor} no está relacionado con el negocio {idNegocio}");
                }

                if (!proveedorNegocio.Activo)
                {
                    _loggerApp.LogInfo(contexto, "La relación ya está desactivada", $"ProveedorId: {idProveedor}, NegocioId: {idNegocio}");
                    return;
                }
                #endregion

                proveedorNegocio.Activo = false;
                _unitOfWork.ProveedoresNegocio.UpdateAsync(proveedorNegocio);
                await _unitOfWork.CompleteAsync();

                _loggerApp.LogInfo(contexto, "Proveedor desactivado para el negocio exitosamente",
                    $"ProveedorId: {idProveedor}, NegocioId: {idNegocio}");
            }
            catch (Exception ex)
            {
                _loggerApp.LogError(contexto, "Error inesperado en la desactivación de proveedor para el negocio", ex.ToString());
                throw;
            }
        }


        public async Task Modify(int negocioId,int proveedorId, ProveedorModifiedRequest proveedorModifiedRequest)
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
                #region Validar relación proveedor-negocio
                _loggerApp.LogInfo(contexto, "Validando relación proveedor-negocio",
                    $"ProveedorId: {proveedorId}, NegocioId: {negocioId}");

                var proveedorNegocio = await _unitOfWork.ProveedoresNegocio.GetByIdsAsync(proveedorId, negocioId);
                if (proveedorNegocio == null)
                {
                    _loggerApp.LogError(contexto, "El proveedor no pertenece al negocio",
                        $"ProveedorId: {proveedorId}, NegocioId: {negocioId}");
                    throw ExceptionApp.BadRequest($"El proveedor con id: {proveedorId} no pertenece al negocio con id: {negocioId}");
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
