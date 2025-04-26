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
            string contexto = $"{this.GetType().Name} - {nameof(CreateClienteAsync)}";
            _logger.LogInfo(contexto, "Iniciando metodo");
            if (!Enum.IsDefined(typeof(TipoDocumento), newCliente.TipoDocumento))
            {
                _logger.LogError(contexto, $"TipoDocumento inválido: {newCliente.TipoDocumento}");
                throw ExceptionApp.BadRequest($"TipoDocumento no válido: {newCliente.TipoDocumento}");
            }
           

            try
            {

                _logger.LogInfo(contexto, $"Consultando si existe el cliente con id:{newCliente.NegocioId}");
                var negocio = await _unitOfWork.Negocios.GetByIdAsync(newCliente.NegocioId);
                if (negocio == null)
                {
                    _logger.LogError(contexto, $"No se encontro el Id del Negocio:{newCliente.NegocioId}");

                    throw ExceptionApp.NotFound($"El negocio con Id: {newCliente.NegocioId} no existe");
                }
                var entidad = ClienteMapping.ToEntity(newCliente);

                var creado = await _unitOfWork.Clientes.AddAsync(entidad);
                await _unitOfWork.CompleteAsync();

                _logger.LogInfo(contexto, $"El cliente fue creado con exito. Id:{creado.Id}");

            }

            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado creando cliente", ex.Message);

                throw;
            }


        }


        public async Task DeleteClienteAsync(int id)
        {
            string contexto = $"{this.GetType().Name} - {nameof(DeleteClienteAsync)}";

            _logger.LogInfo(contexto, "Iniciando metodo");

            try
            {
                _logger.LogInfo(contexto, $"Consultando si existe el cliente con id:{id}");
                var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
                if (cliente == null || !cliente.Activo)
                {
                    _logger.LogInfo(contexto, $"No se encontro el cliente con  id:{id}");

                    throw ExceptionApp.NotFound($"El cliente con Id: {id} no existe");
                }
                _logger.LogInfo(contexto, $"Se recupero con exito el cliente con id:{id}");


                await _unitOfWork.Clientes.SoftDeleteAsync(id);
                await _unitOfWork.CompleteAsync();

                _logger.LogInfo(contexto, $"El cliente con  id:{id} fue eliminado con exito");
            }
            catch (Exception ex)
            {
                _logger.LogInfo(contexto, $"Ocurrio un error inesperado. Error:{ex.Message}");

                throw;
            }
        }

        public async Task<ClienteResponse> GetClienteByIdAsync(int id)
        {
            string contexto = $"{this.GetType().Name} - {nameof(CreateClienteAsync)}";
            _logger.LogInfo(contexto, "Iniciando metodo");

            try
            {
                _logger.LogInfo(contexto, $"Consultando si existe el cliente con id:{id}");
                var entidad = await _unitOfWork.Clientes.GetByIdAsync<int>(id);
                if (entidad == null || !entidad.Activo)
                {
                    _logger.LogError(contexto, $"No se encontro el cliente con id:{id}");
                    throw ExceptionApp.NotFound($"El cliente con Id: {id} no existe");


                }
                var dto = ClienteMapping.ToResponse(entidad);
                _logger.LogInfo(contexto, $"Se recupero con exito el cliente con id:{id}");

                return dto;


            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado consultando cliente con id:{id}", ex.Message);
                throw;
            }
        }
        public async Task<PagedResponse<ClienteResponse>> GetClientesAsync(int pageNumber, int pageSize, bool onlyActive = true)
        {
            string contexto = $"{this.GetType().Name} - {nameof(CreateClienteAsync)}";
            _logger.LogInfo(contexto, "Iniciando metodo");
            try
            {
                _logger.LogInfo(contexto, $"Consultando si existe el cliente con id:{pageNumber}");

                var (entidades, total) = await _unitOfWork.Clientes.GetPageAsync(pageNumber, pageSize, onlyActive);
                var dtos = entidades.Select(ClienteMapping.ToResponse);
                var paged = new PagedResponse<ClienteResponse>
                {
                    Items = dtos,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = total
                };
                return paged;

            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(GetClientesAsync), $"Error listando clientes (onlyActive={onlyActive})", ex.Message);

                throw;
            }
        }

        public async Task UpdateClienteAsync(int id, ClienteRequest req)
        {
            string contexto = $"{this.GetType().Name} - {nameof(UpdateClienteAsync)}";
            _logger.LogInfo(contexto, "Iniciando metodo");
            try
            {
                _logger.LogInfo(contexto, $"Consultando si existe el cliente con id:{id}");
                var entidad = await _unitOfWork.Clientes.GetByIdAsync(id);
                if (entidad == null || !entidad.Activo)
                {
                    _logger.LogError(contexto, $"No se encontro el cliente con id:{id}");

                    throw ExceptionApp.NotFound($"El cliente con Id: {id} no existe");
                }
                if (!Enum.IsDefined(typeof(TipoDocumento), req.TipoDocumento))
                {
                    _logger.LogError(contexto, $"TipoDocumento inválido: {req.TipoDocumento}");
                    throw ExceptionApp.BadRequest($"TipoDocumento no válido: {req.TipoDocumento}");
                }
                // Mapeo manual
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
                _logger.LogInfo(contexto, $"El cliente con id:{id} fue actualizado con exito");
            }


            catch (Exception ex)
            {
                _logger.LogError(nameof(UpdateClienteAsync), $"Error inesperado actualizando {id}", ex.Message);
                throw;
            }
        }
    }
}
