using Application.Common;
using Application.Interfaces;
using Application.Mappings;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using System.Security.Cryptography;

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

        public async Task<PagedResponse<PuestoResponse>> GetAll(int negocioId, int pageNumber, int pageSize)
        {
            string contexto = $"{this.GetType().Name} - {nameof(GetAll)}";

            _logger.LogInfo(contexto, "Inicializando método");

            #region Validaciones
            Negocio? negocio = await _unitOfWork.Negocios.GetByIdAsync(negocioId);
            if (negocio is null)
            {
                _logger.LogError(contexto, $"El id del negocio no es válido: NegocioId: {negocioId}");
                throw ExceptionApp.BadRequest("El id de negocio no es válido.");
            }

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
                var (puestos, totalItems) = await _unitOfWork.Puestos.GetPageAsync(negocioId, pageNumber, pageSize, onlyActive: true);
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

        public async Task<PuestoResponse?> GetById(int negocioId, int id)
        {
            string contexto = $"{this.GetType().Name} - {nameof(GetById)}";

            _logger.LogInfo(contexto, "Inicializando método");

            try
            {
                #region Validaciones
                //primero que todo validamos el id del negocio
                Negocio? negocio = await _unitOfWork.Negocios.GetByIdAsync(negocioId);
                if (negocio is null)
                {
                    _logger.LogError(contexto, $"El id del negocio no es válido: NegocioId: {negocioId}");
                    throw ExceptionApp.BadRequest("El id de negocio no es válido."); //se podria devolver notfound tambien
                }

                var puesto = await _unitOfWork.Puestos.GetByIdAsync(id);
                if (puesto == null)
                {
                    _logger.LogError(contexto, $"No se encontró el puesto con ID {id}.");
                    throw ExceptionApp.NotFound($"No se encontró el puesto con ID {id}.");
                }

                #endregion
                if (puesto.NegocioId != negocioId)
                {
                    _logger.LogError(contexto, "El puesto no pertenece al negocio indicado.");
                    throw ExceptionApp.BadRequest("El puesto no pertenece al negocio indicado.");
                }
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
        private async Task<Puesto?> ValidateByMac(string mac)
        {
            string contexto = $"{this.GetType().Name} - {nameof(ValidateByMac)}";

            _logger.LogInfo(contexto, "Inicializando método");

            try
            {
                Puesto? puesto = await _unitOfWork.Puestos.GetByMac(mac);
                if(puesto == null)
                {
                    _logger.LogError(contexto, $"No se encontro un puesto con direccionMAC: {mac}");
                    throw ExceptionApp.NotFound($"No se encontro un puesto con direccionMAC: {mac}");
                }
                _logger.LogInfo(contexto, "Fin método");
                return puesto;
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado. Error: {ex.Message}");
                throw;
            }
        }
        private async Task<Puesto?> ValidateByIp(string ip)
        {
            string contexto = $"{this.GetType().Name} - {nameof(ValidateByIp)}";

            _logger.LogInfo(contexto, "Inicializando método");

            try
            {
                Puesto? puesto = await _unitOfWork.Puestos.GetByIp(ip);
                if (puesto == null)
                {
                    _logger.LogError(contexto, $"No se encontro un puesto con direccionIP: {ip}");
                    throw ExceptionApp.NotFound($"No se encontro un puesto con direccionIP: {ip}");
                }
                _logger.LogInfo(contexto, "Fin método");
                return puesto;

            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado. Error: {ex.Message}");
                throw;
            }
        }
        public async Task<PuestoResponse> Register(PuestoRequest request)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Register)}";
            _logger.LogInfo(contexto, "Inicializando método.");

            try
            {

                #region validaciones
                var negocio = await _unitOfWork.Negocios.GetByIdAsync(request.NegocioId);
                if (negocio == null)
                {
                    _logger.LogError(contexto, $"No existe un negocio con ID {request.NegocioId}.");
                    throw ExceptionApp.NotFound($"No existe el negocio con ID {request.NegocioId}.");
                }

                if (request.DireccionIP is not null)
                {
                    Puesto? puestoExistente = await ValidateByIp(request.DireccionIP);
                    if (puestoExistente is not null)
                    {
                        _logger.LogError(contexto, $"Ya existe un puesto con la misma IP: {request.DireccionIP}");
                        throw ExceptionApp.BadRequest("La ip que está intentando usar ya se encuentra en uso.");
                    }
                }
                if (request.DireccionMAC is not null)
                {
                    Puesto? puestoExistente = await ValidateByMac(request.DireccionMAC);
                    if (puestoExistente is not null)
                    {
                        _logger.LogError(contexto, $"Ya existe un puesto con la misma MAC: {request.DireccionMAC}");
                        throw ExceptionApp.BadRequest("La MAC que está intentando usar ya se encuentra en uso.");
                    }
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

        public async Task<PuestoResponse> Modify(int id, PuestoRequest request)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Modify)}";
            _logger.LogInfo(contexto, "Inicializando método.");

            try
            {
                #region Validaciones
                Negocio? negocio = await _unitOfWork.Negocios.GetByIdAsync(request.NegocioId);
                if (negocio is null)
                {
                    _logger.LogError(contexto, $"El id del negocio no es válido: NegocioId: {request.NegocioId}");
                    throw ExceptionApp.BadRequest("El id de negocio no es válido.");
                }

                var puesto = await _unitOfWork.Puestos.GetById(id, request.NegocioId);
                if (puesto == null)
                {
                    _logger.LogError(contexto, $"No se encontró el puesto con ID {id}.");
                    throw ExceptionApp.NotFound($"No existe un puesto con el ID {id}.");
                }

                if (request.DireccionIP is not null)
                {
                    Puesto? puestoExistente = await ValidateByIp(request.DireccionIP);
                    if (puestoExistente is not null)
                    {
                        if (!puestoExistente.Id.Equals(id))
                        {
                            _logger.LogError(contexto, $"Ya existe un puesto con la misma IP: {request.DireccionIP}");
                            throw ExceptionApp.BadRequest("La ip que está intentando usar ya se encuentra en uso.");
                        }
                    }
                }
                if (request.DireccionMAC is not null)
                {
                    Puesto? puestoExistente = await ValidateByMac(request.DireccionMAC);
                    if (puestoExistente is not null)
                    {
                        if (!puestoExistente.Id.Equals(id))
                        {
                            _logger.LogError(contexto, $"Ya existe un puesto con la misma MAC: {request.DireccionMAC}");
                            throw ExceptionApp.BadRequest("La MAC que está intentando usar ya se encuentra en uso.");
                        }
                    }
                }
                #endregion

                var puestoUpdated = PuestoMapping.UpdatePuesto(puesto, request);

                await _unitOfWork.Puestos.UpdateAsync(puestoUpdated);
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

        public async Task Disable(int negocioId, int id)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Disable)}";
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

                if (puesto.NegocioId == negocioId)
                {
                    await _unitOfWork.Puestos.SoftDeleteAsync(puesto.Id);
                    await _unitOfWork.CompleteAsync();
                    _logger.LogInfo(contexto, $"Se dio de baja el puesto con ID {id} correctamente.");
                }
                else
                {
                    throw ExceptionApp.BadRequest($"El puesto no pertenece al negocio indicado.");
                }
                #endregion

            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error al dar de baja el puesto. Error: {ex.Message}");
                throw;
            }
        }
    }
}
