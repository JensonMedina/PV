using Application.Common;
using Application.Interfaces;
using Application.Mappings;
using Application.Models.Request;
using Application.Models.Response;

namespace Application.Services
{
    public class PuestoService : IPuestoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerApp _logger;

        public PuestoService(IUnitOfWork unitOfWork, ILoggerApp logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PagedResponse<PuestoResponse>> GetAllAsync(int pageNumber, int pageSize)
        {
            string contexto = $"{this.GetType().Name} - {nameof(GetAllAsync)}";

            _logger.LogInfo(contexto, "Inicializando método");

            #region Validaciones
            if (pageNumber <= 0)
            {
                _logger.LogError(contexto, "El número de página debe ser mayor a cero.");
                throw ExceptionApp.BadRequest("El número de página debe ser mayor a cero.");
            }

            if (pageSize <= 0)
            {
                _logger.LogError(contexto, "El tamaño de página debe ser mayor a cero.");
                throw ExceptionApp.BadRequest("El tamaño de página debe ser mayor a cero.");
            }
            #endregion
            try
            {
                var (puestos, totalItems) = await _unitOfWork.Puestos.GetPageAsync(pageNumber, pageSize, onlyActive: true);

                #region Validaciones
                if (totalItems == 0)
                {
                    _logger.LogError(contexto, "No se encontraron puestos en la base de datos.");
                    throw ExceptionApp.NotFound("No se encontraron puestos.");
                }
                if (!puestos.Any())
                {
                    _logger.LogWarning(contexto, $"No hay puestos para la página {pageNumber}. Total de puestos: {totalItems}.");
                }
                #endregion

                var puestosResponse = puestos.Select(PuestoMapping.ToResponse).ToList();

                var pagedResponse = new PagedResponse<PuestoResponse>(puestosResponse, totalItems, pageNumber, pageSize);

                _logger.LogInfo(contexto, $"Se listaron {puestosResponse.Count} puestos en la página {pageNumber} correctamente.");

                return pagedResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error al listar puestos. Error: {ex.Message}");
                throw;
            }
        }

        public async Task<PuestoResponse?> GetByIdAsync(int id)
        {
            string contexto = $"{this.GetType().Name} - {nameof(GetByIdAsync)}";

            _logger.LogInfo(contexto, "Inicializando método");

            try
            {
                var puesto = await _unitOfWork.Puestos.GetByIdAsync(id);

                #region Validaciones
                if (puesto == null)
                {
                    _logger.LogError(contexto, $"No se encontró el puesto con ID {id}.");
                    throw ExceptionApp.NotFound($"No se encontró el puesto con ID {id}.");
                }
                #endregion

                var response = PuestoMapping.ToResponse(puesto);

                _logger.LogInfo(contexto, $"Se obtuvo el puesto con ID {id}.");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error al obtener el puesto con ID {id}. Error: {ex.Message}");
                throw;
            }
        }

        public async Task<PuestoResponse> AddAsync(PuestoRequest request)
        {
            string contexto = $"{this.GetType().Name} - {nameof(AddAsync)}";
            _logger.LogInfo(contexto, "Inicializando método.");

            try
            {
                var puestosExistentes = await _unitOfWork.Puestos.ListAsync();

                #region validaciones
                if (puestosExistentes.Any(p => p.DireccionIP == request.DireccionIP))
                {
                    _logger.LogError(contexto, $"Ya existe un puesto con la misma IP: {request.DireccionIP}");
                    throw ExceptionApp.BadRequest($"Ya existe un puesto registrado con la misma Dirección IP.");
                }
                if (puestosExistentes.Any(p => p.DireccionMAC == request.DireccionMAC))
                {
                    _logger.LogError(contexto, $"Ya existe un puesto con la misma IP: {request.DireccionMAC}");
                    throw ExceptionApp.BadRequest($"Ya existe un puesto registrado con la misma Dirección MAC.");
                }

                var negocio = await _unitOfWork.Negocios.GetByIdAsync(request.NegocioId);

                if (negocio == null)
                {
                    _logger.LogError(contexto, $"No existe un negocio con ID {request.NegocioId}.");
                    throw ExceptionApp.NotFound($"No existe el negocio con ID {request.NegocioId}.");
                }
                #endregion

                var puesto = PuestoMapping.ToEntity(request);

                await _unitOfWork.Puestos.AddAsync(puesto);
                await _unitOfWork.CompleteAsync();

                _logger.LogInfo(contexto, $"Se creó un nuevo puesto con nombre {puesto.Nombre}.");

                return PuestoMapping.ToResponse(puesto);
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error al crear un nuevo puesto. Error: {ex.Message}");
                throw;
            }
        }

        public async Task<PuestoResponse> UpdateAsync(int id, PuestoRequest request)
        {
            string contexto = $"{this.GetType().Name} - {nameof(UpdateAsync)}";
            _logger.LogInfo(contexto, "Inicializando método.");

            try
            {
                #region Validaciones
                var puestosExistentes = await _unitOfWork.Puestos.ListAsync();
                var puesto = await _unitOfWork.Puestos.GetByIdAsync(id);

                // Validación si el puesto existe
                if (puesto == null)
                {
                    _logger.LogError(contexto, $"No se encontró el puesto con ID {id}.");
                    throw ExceptionApp.NotFound($"No existe un puesto con el ID {id}.");
                }

                // Solo validamos IP si ha cambiado
                if (request.DireccionIP != puesto.DireccionIP && puestosExistentes.Any(p => p.DireccionIP == request.DireccionIP))
                {
                    _logger.LogError(contexto, $"Ya existe un puesto con la misma IP: {request.DireccionIP}");
                    throw ExceptionApp.BadRequest($"Ya existe un puesto registrado con la misma Dirección IP.");
                }

                if (request.DireccionMAC != puesto.DireccionMAC && puestosExistentes.Any(p => p.DireccionMAC == request.DireccionMAC))
                {
                    _logger.LogError(contexto, $"Ya existe un puesto con la misma Dirección MAC: {request.DireccionMAC}");
                    throw ExceptionApp.BadRequest($"Ya existe un puesto registrado con la misma Dirección MAC.");
                }
                #endregion

                if (request.Nombre != puesto.Nombre)
                    puesto.Nombre = request.Nombre;

                if (request.TipoImpresora != puesto.TipoImpresora)
                    puesto.TipoImpresora = request.TipoImpresora;

                if (request.ImpresoraConfigurada != puesto.ImpresoraConfigurada)
                    puesto.ImpresoraConfigurada = request.ImpresoraConfigurada;

                if (request.NegocioId > 0 && request.NegocioId != puesto.NegocioId)
                    puesto.NegocioId = request.NegocioId;

                await _unitOfWork.Puestos.UpdateAsync(puesto);
                await _unitOfWork.CompleteAsync();

                _logger.LogInfo(contexto, $"Se actualizó el puesto con id {id} correctamente.");

                return PuestoMapping.ToResponse(puesto);
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error al actualizar el puesto. Error: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            string contexto = $"{this.GetType().Name} - {nameof(DeleteAsync)}";
            _logger.LogInfo(contexto, "Inicializando método.");
            
            try
            {
                #region Validaciones
                var puesto = await _unitOfWork.Puestos.GetByIdAsync(id);

                if (puesto == null)
                {
                    _logger.LogError(contexto, $"No se encontró el puesto con ID {id}.");
                    throw ExceptionApp.NotFound($"No existe un puesto con el ID {id}.");
                }

                if (!puesto.Activo)
                {
                    _logger.LogError(contexto, $"El puesto con ID {id} ya está inactivo.");
                    throw ExceptionApp.BadRequest($"El puesto con ID {id} ya fue dado de baja anteriormente.");
                }
                #endregion
                await _unitOfWork.Puestos.SoftDeleteAsync(puesto.Id);
                await _unitOfWork.CompleteAsync();

                _logger.LogInfo(contexto, $"Se dio de baja el puesto con ID {id} correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error al dar de baja el puesto. Error: {ex.Message}");
                throw;
            }
        }
    }
}
