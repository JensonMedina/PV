using Application.Common;
using Application.Interfaces;
using Application.Mappings;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;


namespace Infrastructure.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerApp _logger;

        public ClienteService(IUnitOfWork uow, ILoggerApp log)
        {
            _unitOfWork = uow;
            _logger = log;
        }

        public async Task Register(ClienteRequest newCliente)
        {
            string contexto = $"{GetType().Name} - {nameof(Register)}";
            _logger.LogInfo(contexto, "Iniciando método CreateClienteAsync");
            try
            {
                #region Validacion Negocio

                var negocio = await _unitOfWork.Negocios.GetByIdAsync(newCliente.NegocioId);
                if (negocio == null)
                {
                    _logger.LogError(contexto, $"Negocio no encontrado. Id:{newCliente.NegocioId}");
                    throw ExceptionApp.NotFound($"El negocio con Id {newCliente.NegocioId} no existe");
                }
                #endregion

                #region Validacion Email
                Cliente? clienteExistente = await _unitOfWork.Clientes.GetByEmail(newCliente.Email, newCliente.NegocioId);
                if (clienteExistente is not null)
                {
                    _logger.LogError(contexto, $"Email ya registrado en negocio {newCliente.NegocioId}: {newCliente.Email}");
                    throw ExceptionApp.Conflict($"El correo {newCliente.Email} ya está en uso en ese negocio");
                }
                #endregion
                #region Validacion Documento

                if (newCliente.NumeroDocumento is not null)
                {
                    _logger.LogInfo(contexto, $"Validando número de documento: {newCliente.NumeroDocumento}");

                    clienteExistente = await _unitOfWork.Clientes.NumeroDocumentoExist(newCliente.NumeroDocumento, newCliente.NegocioId);
                    if (clienteExistente is not null)
                    {
                        _logger.LogError(contexto, $"Número de documento ya registrado en negocio {newCliente.NegocioId}: {newCliente.NumeroDocumento}");
                        throw ExceptionApp.Conflict($"El número de documento {newCliente.NumeroDocumento} ya está en uso en ese negocio");
                    }
                }
                #endregion


                var entidad = ClienteMapping.ToEntity(newCliente);
                var creado = await _unitOfWork.Clientes.AddAsync(entidad);
                await _unitOfWork.CompleteAsync();

                _logger.LogInfo(contexto, $"Cliente creado con éxito. Id:{creado.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado creando cliente: {ex.Message}");
                throw;

            }
        }


        public async Task Disable(int id, int negocioId)
        {
            string contexto = $"{GetType().Name} - {nameof(Disable)}";
            _logger.LogInfo(contexto, "Iniciando método DeleteClienteAsync");

            if (id <= 0)
                throw ExceptionApp.BadRequest("Id de cliente debe ser mayor que cero");
            if (negocioId <= 0)
                throw ExceptionApp.BadRequest("Id de negocio debe ser mayor que cero");

            try
            {
                _logger.LogInfo(contexto, $"Consultando cliente con id:{id}");
                var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);

                if (cliente == null || !cliente.Activo)
                {
                    _logger.LogError(contexto, $"Cliente no encontrado o inactivo con id:{id}");
                    throw ExceptionApp.NotFound($"El cliente con Id: {id} no existe");
                }

                if (cliente.NegocioId != negocioId)
                {
                    _logger.LogError(contexto, $"Acceso denegado. Cliente {id} no pertenece al negocio {negocioId}");
                    throw ExceptionApp.Forbidden("No tienes permiso para eliminar este cliente");
                }

                await _unitOfWork.Clientes.SoftDeleteAsync(id);
                await _unitOfWork.CompleteAsync();

                _logger.LogInfo(contexto, $"Cliente eliminado con éxito. Id:{id}");
            }
            catch (ExceptionApp)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado eliminando cliente. Error: {ex.Message}");
                throw;
            }
        }

        public async Task<ClienteResponse> GetById(int id)
        {
            string contexto = $"{GetType().Name} - {nameof(GetById)}";
            _logger.LogInfo(contexto, "Iniciando método GetClienteByIdAsync");

            try
            {
                if (id <= 0)
                    throw ExceptionApp.BadRequest("Id debe ser mayor que cero");

                _logger.LogInfo(contexto, $"Consultando cliente con id:{id}");
                var entidad = await _unitOfWork.Clientes.GetByIdAsync(id);
                if (entidad == null || !entidad.Activo)
                    throw ExceptionApp.NotFound($"El cliente con Id: {id} no existe");

                var dto = ClienteMapping.ToResponse(entidad);
                _logger.LogInfo(contexto, $"Cliente recuperado con éxito. Id:{id}");
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado consultando cliente. Error: {ex.Message}");
                throw;
            }
        }

        public async Task<PagedResponse<ClienteResponse>> GetAll(int pageNumber, int pageSize, bool onlyActive = true, int negocioId = 0)
        {
            string contexto = $"{GetType().Name} - {nameof(GetAll)}";
            _logger.LogInfo(contexto, "Iniciando método GetClientesAsync");

            if (pageNumber <= 0 || pageSize <= 0)
                throw ExceptionApp.BadRequest("PageNumber y PageSize deben ser mayores que cero");
            if (negocioId <= 0)
                throw ExceptionApp.BadRequest("NegocioId debe ser mayor que cero");

            try
            {
                // Verifico que exista el negocio
                var negocio = await _unitOfWork.Negocios.GetByIdAsync(negocioId);
                if (negocio == null)
                {
                    _logger.LogError(contexto, $"Negocio no encontrado. Id:{negocioId}");
                    throw ExceptionApp.NotFound($"El negocio con Id {negocioId} no existe");
                }
                _logger.LogInfo(contexto,
                    $"Obteniendo página {pageNumber} (size={pageSize}, onlyActive={onlyActive}) para negocio {negocioId}");

                var (entidades, totalItems) = await _unitOfWork.Clientes.GetPageAsync(negocioId, pageNumber, pageSize, onlyActive: true);
                var clientesResponse = entidades.Select(ClienteMapping.ToResponse).ToList();

                var pagedResponse = new PagedResponse<ClienteResponse>(clientesResponse, totalItems, pageNumber, pageSize);
                _logger.LogInfo(contexto,
                    $"Página {pageNumber} obtenida con éxito. Total registros: {totalItems} para negocio {negocioId}");

                return pagedResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado listando clientes. Error: {ex.Message}");
                throw;
            }
        }


        public async Task Modify(int id, ClienteModifyRequest request)
        {
            string contexto = $"{GetType().Name} - {nameof(Modify)}";
            _logger.LogInfo(contexto, "Iniciando");
            try
            {
                #region Validaciones
                //Validamos que el id del cliente sea positivo
                if (id <= 0)
                {
                    _logger.LogError(contexto, "Id de cliente inválido (debe ser > 0)");
                    throw ExceptionApp.BadRequest("Id de cliente debe ser mayor que cero");
                }
                //Validamos que el id del negocio sea positivo
                if (request.NegocioId <= 0)
                {
                    _logger.LogError(contexto, "Id de negocio debe ser mayor que cero");
                    throw ExceptionApp.BadRequest("Id de negocio debe ser mayor que cero");
                }

                #region Validacion Negocio
                _logger.LogInfo(contexto, $"Consultando cliente con id:{id}");
                var negocio = await _unitOfWork.Negocios.GetByIdAsync(request.NegocioId);
                if (negocio is null)
                {
                    _logger.LogError(contexto, $"El negocio con id: {request.NegocioId} no se encontró.");
                    throw ExceptionApp.NotFound($"El negocio con id: {request.NegocioId} no se encontró.");
                }
                #endregion

                #region Validacion Cliente
                _logger.LogInfo(contexto, $"Consultando cliente con id:{id}");
                Cliente? cliente = await _unitOfWork.Clientes.GetByIdAsync(id);

                if (cliente == null || !cliente.Activo)
                {
                    _logger.LogError(contexto, $"Cliente no encontrado o inactivo con id:{id}");
                    throw ExceptionApp.NotFound($"El cliente con Id: {id} no existe");
                }

                if (!cliente.NegocioId.Equals(request.NegocioId))
                {
                    _logger.LogError(contexto, "El Cliente no pertenece a este negocio.");
                    throw ExceptionApp.Conflict("El Cliente no pertenece a este negocio.");
                }
                #endregion

                #region Validacion Email
                if (request.Email is not null)
                {
                    Cliente? clienteExistente = await _unitOfWork.Clientes.GetByEmail(request.Email, request.NegocioId);
                    if (clienteExistente is not null && !clienteExistente.Id.Equals(cliente.Id))
                    {
                        _logger.LogError(contexto, $"Email ya registrado en negocio {request.NegocioId}: {request.Email}");
                        throw ExceptionApp.Conflict($"El correo {request.Email} ya está en uso en ese negocio");
                    }
                }
                #endregion
                #region Validacion Documento
                // Validamos que el número de documento no esté en uso por otro cliente
                if (request.NumeroDocumento is not null)
                {
                    _logger.LogInfo(contexto, $"Validando número de documento: {request.NumeroDocumento}");

                    Cliente? clienteExistente = await _unitOfWork.Clientes.NumeroDocumentoExist(request.NumeroDocumento, request.NegocioId);
                    if (clienteExistente is not null && !clienteExistente.Id.Equals(cliente.Id))
                    {
                        _logger.LogError(contexto, $"Número de documento ya registrado en negocio {request.NegocioId}: {request.NumeroDocumento}");
                        throw ExceptionApp.Conflict($"El número de documento {request.NumeroDocumento} ya está en uso en ese negocio");
                    }
                }
                #endregion

                #region Mapeamos de modify a entidad
                try
                {
                    _logger.LogInfo(contexto, "Mapeando entidad");
                    cliente = ClienteMapping.FromUpdatedToEntity(cliente, request);
                }
                catch (Exception ex)
                {
                    _logger.LogError(contexto, $"Ocurrió un error al mapear: {ex}");
                    throw;
                }
                #endregion
                 _unitOfWork.Clientes.UpdateAsync(cliente);
                await _unitOfWork.CompleteAsync();
                _logger.LogInfo(contexto, $"Cliente actualizado con éxito. Id:{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado actualizando cliente. Error: {ex.Message}");
                throw;
            }
        }

    }
}
#endregion