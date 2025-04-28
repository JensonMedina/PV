using Application.Common;
using Application.Interfaces;
using Application.Mappings;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Enum;


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

        public async Task CreateClienteAsync(ClienteRequest newCliente)
        {
            string contexto = $"{GetType().Name} - {nameof(CreateClienteAsync)}";
            _logger.LogInfo(contexto, "Iniciando método CreateClienteAsync");


            var negocio = await _unitOfWork.Negocios.GetByIdAsync(newCliente.NegocioId);
            if (negocio == null)
            {
                _logger.LogError(contexto, $"Negocio no encontrado. Id:{newCliente.NegocioId}");
                throw ExceptionApp.NotFound($"El negocio con Id {newCliente.NegocioId} no existe");
            }

            var existeEmail = await _unitOfWork.Clientes.ExistsByEmailAsync(newCliente.Email);
            if (existeEmail)
            {
                _logger.LogError(contexto, $"Email ya registrado: {newCliente.Email}");
                throw ExceptionApp.Conflict($"El correo {newCliente.Email} ya está en uso");
            }

            try
            {

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


        public async Task DeleteClienteAsync(int id)
        {
            string contexto = $"{GetType().Name} - {nameof(DeleteClienteAsync)}";
            _logger.LogInfo(contexto, "Iniciando método DeleteClienteAsync");
            if (id <= 0)
                throw ExceptionApp.BadRequest("Id debe ser mayor que cero");
            try
            {
                _logger.LogInfo(contexto, $"Consultando cliente con id:{id}");
                var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
                if (cliente == null || !cliente.Activo)
                {
                    _logger.LogError(contexto, $"Cliente no encontrado o inactivo con id:{id}");
                    throw ExceptionApp.NotFound($"El cliente con Id: {id} no existe");
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

        public async Task<ClienteResponse> GetClienteByIdAsync(int id)
        {
            string contexto = $"{GetType().Name} - {nameof(GetClienteByIdAsync)}";
            _logger.LogInfo(contexto, "Iniciando método GetClienteByIdAsync");
            if (id <= 0)
                throw ExceptionApp.BadRequest("Id debe ser mayor que cero");

            try
            {
                _logger.LogInfo(contexto, $"Consultando cliente con id:{id}");
                var entidad = await _unitOfWork.Clientes.GetByIdAsync<int>(id);
                if (entidad == null || !entidad.Activo)
                {
                    _logger.LogError(contexto, $"Cliente no encontrado o inactivo con id:{id}");
                    throw ExceptionApp.NotFound($"El cliente con Id: {id} no existe");
                }
                var dto = ClienteMapping.ToResponse(entidad);
                _logger.LogInfo(contexto, $"Cliente recuperado con éxito. Id:{id}");
                return dto;
            }
            catch (ExceptionApp)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado consultando cliente. Error: {ex.Message}");
                throw;
            }
        }

        public async Task<PagedResponse<ClienteResponse>> GetClientesAsync(int pageNumber, int pageSize, bool onlyActive = true)
        {
            string contexto = $"{GetType().Name} - {nameof(GetClientesAsync)}";
            _logger.LogInfo(contexto, "Iniciando método GetClientesAsync");


            if (pageNumber <= 0 || pageSize <= 0)
                throw ExceptionApp.BadRequest("PageNumber y PageSize deben ser mayores que cero");

            try
            {
                _logger.LogInfo(contexto, $"Obteniendo página {pageNumber} (size={pageSize}, onlyActive={onlyActive})");
                var (entidades, total) = await _unitOfWork.Clientes.GetPageAsync(pageNumber, pageSize, onlyActive);
                var dtos = entidades.Select(ClienteMapping.ToResponse);
                var paged = new PagedResponse<ClienteResponse>
                {
                    Items = dtos,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = total
                };
                _logger.LogInfo(contexto, $"Página {pageNumber} obtenida con éxito. Total registros: {total}");
                return paged;
            }
            catch (ExceptionApp)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado listando clientes. Error: {ex.Message}");
                throw;
            }
        }


        public async Task UpdateClienteAsync(int id, ClienteRequest req)
        {
            string contexto = $"{GetType().Name} - {nameof(UpdateClienteAsync)}";
            _logger.LogInfo(contexto, "Iniciando método UpdateClienteAsync");

            _logger.LogInfo(contexto, $"Consultando cliente con id:{id}");
            var entidad = await _unitOfWork.Clientes.GetByIdAsync(id);
            if (entidad == null || !entidad.Activo)
            {
                _logger.LogError(contexto, $"Cliente no encontrado o inactivo con id:{id}");
                throw ExceptionApp.NotFound($"El cliente con Id: {id} no existe");
            }
            if (!string.Equals(entidad.Email, req.Email, StringComparison.OrdinalIgnoreCase))
            {
                var existeEmail = await _unitOfWork.Clientes.ExistsByEmailAsync(req.Email);
                if (existeEmail)
                {
                    _logger.LogError(contexto, $"Email ya registrado: {req.Email}");
                    throw ExceptionApp.Conflict($"El correo {req.Email} ya está en uso");
                }
            }

            try
            {

                // Mapeo manual de propiedades
                entidad.Nombre = req.Nombre;
                entidad.Apellido = req.Apellido;
                entidad.Email = req.Email;
                entidad.TipoDocumento = req.TipoDocumento;
                entidad.NumeroDocumento = req.NumeroDocumento;
                entidad.Telefono = req.Telefono;
                entidad.Direccion = req.Direccion;
                entidad.Ciudad = req.Ciudad;
                entidad.Provincia = req.Provincia;
                entidad.CodigoPostal = req.CodigoPostal;
                entidad.EsConsumidorFinal = req.EsConsumidorFinal;
                entidad.LimiteCredito = req.LimiteCredito;
                entidad.SaldoActual = req.SaldoActual;
                entidad.Observaciones = req.Observaciones;
                entidad.PuntosFidelidad = req.PuntosFidelidad;

                await _unitOfWork.Clientes.UpdateAsync(entidad);
                await _unitOfWork.CompleteAsync();
                _logger.LogInfo(contexto, $"Cliente actualizado con éxito. Id:{id}");
            }
            catch (ExceptionApp)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado actualizando cliente. Error: {ex.Message}");
                throw;
            }
        }

    }
}
