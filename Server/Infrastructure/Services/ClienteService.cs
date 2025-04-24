using Application.Common;
using Application.Interfaces;
using Application.Mappings;
using Application.Models.Request;
using Application.Models.Response;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Result<ClienteResponse>> CreateClienteAsync(ClienteRequest req)
        {
            try
            {
                var entidad = ClienteMapping.ToEntity(req);
                var creado = await _unitOfWork.Clientes.AddAsync(entidad);
                await _unitOfWork.CompleteAsync();

                var dto = ClienteMapping.ToResponse(creado);
                return Result<ClienteResponse>.Ok(dto, "Cliente creado");
            }
            catch (DbUpdateException dbEx)
            {
                var sql = dbEx.InnerException?.Message ?? dbEx.Message;
                _logger.LogError(nameof(CreateClienteAsync), "Error al guardar cliente", sql);
                return Result<ClienteResponse>.Error("Error al guardar cliente");
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(CreateClienteAsync), "Error inesperado creando cliente", ex.Message);
                return Result<ClienteResponse>.Error("Error creando cliente");
            }
        }


        public async Task<Result<string>> DeleteClienteAsync(int id)
        {
            try
            {
                var cliente = await _unitOfWork.Clientes.GetByIdAsync<int>(id);
                if (cliente == null || !cliente.Activo)
                    return Result<string>.NotFound("Cliente no encontrado");

                await _unitOfWork.Clientes.SoftDeleteAsync<int>(id);
                await _unitOfWork.CompleteAsync();

                return Result<string>.Ok("Cliente eliminado");
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(DeleteClienteAsync),
                              $"Error eliminando cliente {id}",
                                ex.Message );
                return Result<string>.Error("Error eliminando cliente");
            }
        }

        public async Task<Result<ClienteResponse>> GetClienteByIdAsync(int id)
        {
            try
            {
                var entidad = await _unitOfWork.Clientes.GetByIdAsync<int>(id);
                if (entidad == null || !entidad.Activo)
                    return Result<ClienteResponse>.NotFound("Cliente no encontrado");

                var dto = ClienteMapping.ToResponse(entidad);
                return Result<ClienteResponse>.Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(GetClienteByIdAsync), $"Error obteniendo cliente {id}", ex.Message);
                return Result<ClienteResponse>.Error("Error obteniendo cliente");
            }
        }


        public async Task<Result<PagedResponse<ClienteResponse>>> GetClientesAsync(int pageNumber, int pageSize)
        {
            try
            {
                var (entidades, total) = await _unitOfWork.Clientes.GetPageAsync(pageNumber, pageSize);
                var dtos = entidades.Select(ClienteMapping.ToResponse);
                var paged = new PagedResponse<ClienteResponse>
                {
                    Items = dtos,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = total
                };
                return Result<PagedResponse<ClienteResponse>>.Ok(paged);
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(GetClientesAsync), "Error listando clientes", ex.Message);
                return Result<PagedResponse<ClienteResponse>>.Error("Error listando clientes");
            }
        }

        public async Task<Result<ClienteResponse>> UpdateClienteAsync(int id, ClienteRequest req)
        {
            try
            {
                var entidad = await _unitOfWork.Clientes.GetByIdAsync<int>(id);
                if (entidad == null || !entidad.Activo)
                    return Result<ClienteResponse>.NotFound("Cliente no encontrado");

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

                var dto = ClienteMapping.ToResponse(entidad);
                return Result<ClienteResponse>.Ok(dto, "Cliente actualizado");
            }
            catch (DbUpdateException dbEx)
            {
                var sql = dbEx.InnerException?.Message ?? dbEx.Message;
                _logger.LogError(nameof(UpdateClienteAsync), $"Error actualizando {id}",  sql );
                return Result<ClienteResponse>.Error("Error actualizando cliente");
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(UpdateClienteAsync), $"Error inesperado actualizando {id}",  ex.Message );
                return Result<ClienteResponse>.Error("Error actualizando cliente");
            }
        }
    }
}
