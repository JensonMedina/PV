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

            if (!Enum.IsDefined(typeof(TipoDocumento), newCliente.TipoDocumento))
            {
                _logger.LogError(contexto, $"TipoDocumento inválido: {newCliente.TipoDocumento}");
                throw ExceptionApp.BadRequest($"TipoDocumento no válido: {newCliente.TipoDocumento}");
            }

            try
            {
                _logger.LogInfo(contexto, $"Consultando negocio con id:{newCliente.NegocioId}");
                var negocio = await _unitOfWork.Negocios.GetByIdAsync(newCliente.NegocioId);
                if (negocio == null)
                {
                    _logger.LogError(contexto, $"No se encontró el negocio con id:{newCliente.NegocioId}");
                    throw ExceptionApp.NotFound($"El negocio con Id: {newCliente.NegocioId} no existe");
                }

                var entidad = ClienteMapping.ToEntity(newCliente);
                var creado = await _unitOfWork.Clientes.AddAsync(entidad);
                await _unitOfWork.CompleteAsync();

                _logger.LogInfo(contexto, $"Cliente creado con éxito. Id:{creado.Id}");
            }
            catch (ExceptionApp)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado creando cliente. Error: {ex.Message}");
                throw;
            }
        }


        public async Task DeleteClienteAsync(int id)
        {
            string contexto = $"{GetType().Name} - {nameof(DeleteClienteAsync)}";
            _logger.LogInfo(contexto, "Iniciando método DeleteClienteAsync");
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
            try
            {
                _logger.LogInfo(contexto, $"Consultando cliente con id:{id}");
                var entidad = await _unitOfWork.Clientes.GetByIdAsync(id);
                if (entidad == null || !entidad.Activo)
                {
                    _logger.LogError(contexto, $"Cliente no encontrado o inactivo con id:{id}");
                    throw ExceptionApp.NotFound($"El cliente con Id: {id} no existe");
                }
                if (!Enum.IsDefined(typeof(TipoDocumento), req.TipoDocumento))
                {
                    _logger.LogError(contexto, $"TipoDocumento inválido: {req.TipoDocumento}");
                    throw ExceptionApp.BadRequest($"TipoDocumento no válido: {req.TipoDocumento}");
                }
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
