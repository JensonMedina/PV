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
                var negocio = await ObtenerNegocioValidadoAsync(negocioId, contexto);
                #endregion

                #region Validar Rubro
                _loggerApp.LogInfo(contexto, "Iniciando validación de rubro", $"RubroId: {newProveedor.RubroId}");
                var rubro = await ObtenerRubroValidadoAsync(newProveedor.RubroId, contexto);
                #endregion
                #region Validar Email
                _loggerApp.LogInfo(contexto, "Validando si ya existe proveedor con el mismo email", $"Email: {newProveedor.Email}");

                var proveedorConEmail = await _unitOfWork.Proveedores.GetByEmailAsync(newProveedor.Email);

                if (proveedorConEmail != null)
                {
                    _loggerApp.LogInfo(contexto, "Proveedor ya existe con ese email", $"ProveedorId: {proveedorConEmail.Id}");
                    throw ExceptionApp.Conflict($"Ya existe un proveedor registrado con el email {newProveedor.Email}.");
                }
                #endregion

                #region Validar número de documento de proveedor
                _loggerApp.LogInfo(contexto, "Validando si ya existe proveedor con el mismo documento",
                    $"Documento: {newProveedor.NumeroDocumento}");

                var proveedorExistente = await _unitOfWork.Proveedores.GetByNumeroDocumentoAsync(newProveedor.NumeroDocumento);

                if (proveedorExistente != null)
                {
                    _loggerApp.LogInfo(contexto, "Proveedor ya existe", $"ProveedorId: {proveedorExistente.Id}");

                    throw ExceptionApp.Conflict(
                        $"El proveedor con documento {newProveedor.NumeroDocumento} ya existe. " +
                        $"Si desea asociarlo al negocio, utilice el endpoint de asociación.");
                }
                #endregion
                _loggerApp.LogInfo(contexto, "Validaciones correctas. Mapeando Request a Entidad", $"Documento Proveedor: {newProveedor.NumeroDocumento}, NegocioId: {negocioId}");

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


        public async Task AsociarProveedorExistenteAsync(int proveedorId, int negocioId)
        {
            string contexto = $"{this.GetType().Name} - {nameof(AsociarProveedorExistenteAsync)}";

            try
            {
                _loggerApp.LogInfo(contexto, "Iniciando asociación de proveedor existente a negocio",
                    $"ProveedorId: {proveedorId}, NegocioId: {negocioId}");

                #region Validar Negocio
                var negocio = await ObtenerNegocioValidadoAsync(negocioId, contexto);
                #endregion

                #region Validar Proveedor
                var proveedor = await ObtenerProveedorValidadoAsync(proveedorId, contexto);
                #endregion
                
                #region Verificar si ya existe relación
                var relacionExistente = await _unitOfWork.ProveedoresNegocio
                    .GetByIdsAsync(proveedorId, negocioId);

                if (relacionExistente != null)
                {
                    _loggerApp.LogError(contexto, "Proveedor ya está asociado al negocio",
                        $"ProveedorId: {proveedorId}, NegocioId: {negocioId}");
                    throw ExceptionApp.Conflict("El proveedor ya está asociado a este negocio.");
                }
                #endregion

                var nuevaRelacion = new ProveedorNegocio
                {
                    ProveedorId = proveedorId,
                    NegocioId = negocioId
                };

                await _unitOfWork.ProveedoresNegocio.AddAsync(nuevaRelacion);
                await _unitOfWork.CompleteAsync();

                _loggerApp.LogInfo(contexto, "Asociación proveedor-negocio creada exitosamente",
                    $"ProveedorId: {proveedorId}, NegocioId: {negocioId}");
            }
            catch (Exception ex)
            {
                _loggerApp.LogError(contexto, "Error en la asociación proveedor-negocio", ex.ToString());
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
                var negocio = await ObtenerNegocioValidadoAsync(negocioId, contexto);
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
                var rubro = await ObtenerRubroValidadoAsync(rubroId, contexto);
                #endregion

                _loggerApp.LogInfo(contexto,
                   $"Obteniendo página {pageNumber} (size={pageSize}, onlyActive={onlyActive}) para rubro {rubroId}");

                var (entidades, totalItems) = await _unitOfWork.Proveedores.GetPageByRubroAsync(
                    rubroId,
                    pageNumber,
                    pageSize,
                    onlyActive: onlyActive); 

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
                var negocio = await ObtenerNegocioValidadoAsync(idNegocio, contexto);

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

                #endregion

                _unitOfWork.ProveedoresNegocio.HardDeleteAsync(proveedorNegocio);
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
                var rubro = await ObtenerRubroValidadoAsync(proveedorModifiedRequest.RubroId.Value, contexto);
                #endregion

                #region Validar Proveedor
                _loggerApp.LogInfo(contexto, "Iniciando validación de proveedor", $"ProveedorId: {proveedorId}");
                var proveedor = await ObtenerProveedorValidadoAsync(proveedorId, contexto);
                if (proveedor == null)
                {
                    _loggerApp.LogError(contexto, "Proveedor no encontrado", $"ProveedorId: {proveedorId}");
                    throw ExceptionApp.NotFound($"El proveedor con id: {proveedorId} no existe");
                }
                #endregion
                #region Validar relación proveedor-negocio
                _loggerApp.LogInfo(contexto, "Validando relación proveedor-negocio",
                    $"ProveedorId: {proveedorId}, NegocioId: {negocioId}");

                var proveedorNegocio = await ObtenerRelacionProveedorNegocioValidadaAsync(proveedorId,negocioId,contexto);
                #endregion
                #region Mapeamos de modify a entidad

                _loggerApp.LogInfo(contexto, "Mapeando de Modified a Entidad");
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


        private async Task<Negocio> ObtenerNegocioValidadoAsync(int negocioId, string contexto)
        {
            var negocio = await _unitOfWork.Negocios.GetByIdAsync(negocioId);
            if (negocio == null)
            {
                _loggerApp.LogError(contexto, "Negocio no encontrado", $"NegocioId: {negocioId}");
                throw ExceptionApp.NotFound($"El negocio con id: {negocioId} no existe");
            }
            _loggerApp.LogInfo(contexto, "Negocio encontrado", $"NegocioId: {negocio.Id}");
            return negocio;
        }

        private async Task<Rubro> ObtenerRubroValidadoAsync(int rubroId, string contexto)
        {
            var rubro = await _unitOfWork.Rubros.GetByIdAsync(rubroId);
            if (rubro == null)
            {
                _loggerApp.LogError(contexto, "Rubro no encontrado", $"RubroId: {rubroId}");
                throw ExceptionApp.NotFound($"El rubro con id: {rubroId} no existe");
            }
            _loggerApp.LogInfo(contexto, "Rubro encontrado", $"RubroId: {rubro.Id}");
            return rubro;
        }

        private async Task<Proveedor> ObtenerProveedorValidadoAsync(int proveedorId, string contexto)
        {
            var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(proveedorId);
            if (proveedor == null)
            {
                _loggerApp.LogError(contexto, "Proveedor no encontrado", $"ProveedorId: {proveedorId}");
                throw ExceptionApp.NotFound($"El proveedor con id: {proveedorId} no existe");
            }
            if(!proveedor.Activo) {
                _loggerApp.LogError(contexto, "Proveedor Inactivo", $"ProveedorId: {proveedorId}");
                throw ExceptionApp.BadRequest($"El proveedor con id: {proveedorId} está Inactivo actualmente");
            }     
            _loggerApp.LogInfo(contexto, "Proveedor encontrado y disponible ", $"ProveedorId: {proveedor.Id}");
            return proveedor;
        }

        private async Task<ProveedorNegocio> ObtenerRelacionProveedorNegocioValidadaAsync(int proveedorId, int negocioId, string contexto)
        {
            var relacion = await _unitOfWork.ProveedoresNegocio.GetByIdsAsync(proveedorId, negocioId);
            if (relacion == null)
            {
                _loggerApp.LogError(contexto, "Relación proveedor-negocio no encontrada", $"ProveedorId: {proveedorId} - NegocioId: {negocioId}");
                throw ExceptionApp.NotFound($"La relación entre proveedor y negocio no existe");
            }
            _loggerApp.LogInfo(contexto, "Relación proveedor-negocio encontrada", $"ProveedorId: {proveedorId} - NegocioId: {negocioId}");
            return relacion;
        }

    }
}
