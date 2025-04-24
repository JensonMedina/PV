using Application.Common;
using Application.Interfaces;
using Application.Mappings;
using Application.Models.Request;
using Application.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerApp _logger;

        public ClienteController(IUnitOfWork unitOfWork, ILoggerApp logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllClientes(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (entidades, total) = await _unitOfWork.Clientes.GetPageAsync(pageNumber, pageSize);
                var dtoList = entidades.Select(ClienteMapping.ToResponse);
                var response = new PagedResponse<ClienteResponse>
                {
                    Items = dtoList,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = total
                };
                return Ok(response);
            }
            catch (Exception ex)

            {
                _logger.LogError(nameof(GetAllClientes), "Se produjo un error listando los clientes", ex.Message);
                return StatusCode(500, Result<PagedResponse<ClienteResponse>>.Error("Se produjo un error listando los clientes"));

            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetByClienteId(int id)
        {
            try
            {
                var cliente = await _unitOfWork.Clientes.GetByIdAsync<int>(id);
                if (cliente == null || !cliente.Activo)
                    return NotFound(Result<ClienteResponse>.NotFound("El cliente no se encontro"));

                var dto = ClienteMapping.ToResponse(cliente);
                return Ok(Result<ClienteResponse>.Ok(dto));

            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(GetByClienteId), $"Error obteniendo cliente {id}", ex.Message);
                return StatusCode(500, Result<ClienteResponse>.Error("Se produjo un error al buscar el cliente"));
            }

        }
        [HttpPost]
        public async Task<ActionResult> CreateCliente([FromBody] ClienteRequest clienteRequest)
        {
            try
            {
                var entidad = ClienteMapping.ToEntity(clienteRequest);
                var creado = await _unitOfWork.Clientes.AddAsync(entidad);
                await _unitOfWork.CompleteAsync();

                var dto = ClienteMapping.ToResponse(creado);
                return Ok(Result<ClienteResponse>.Ok(dto, "Cliente creado exitosamente"));

            }
            catch (DbUpdateException dbEx)
            {
                var sqlError = dbEx.InnerException?.Message ?? dbEx.Message;
                _logger.LogError(nameof(CreateCliente), "Validacion al crear el cliente", sqlError);
                return UnprocessableEntity(Result<ClienteResponse>.ValidationError(sqlError));

            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(CreateCliente), "Se produjo un error crear el cliente", ex.Message);
                return StatusCode(500, Result<ClienteResponse>.Error("Se produjo un error crear el cliente"));
            }

        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCliente(int id, ClienteRequest request)
        {
            try
            {
                var entidad = await _unitOfWork.Clientes.GetByIdAsync<int>(id);
                if (entidad == null || !entidad.Activo)
                    return NotFound(Result<ClienteResponse>.NotFound("El cliente no se encontro"));

                entidad.Nombre = request.Nombre;
                entidad.Email = request.Email;
                entidad.NegocioId = request.NegocioId;
                entidad.Apellido = request.Apellido;
                entidad.TipoDocumento = request.TipoDocumento;
                entidad.NumeroDocumento = request.NumeroDocumento;
                entidad.Telefono = request.Telefono;
                entidad.Direccion = request.Direccion;
                entidad.LimiteCredito = request.LimiteCredito;
                entidad.Observaciones = request.Observaciones;
                entidad.PuntosFidelidad = request.PuntosFidelidad;
                entidad.SaldoActual = request.SaldoActual;
                entidad.Ciudad = request.Ciudad;
                entidad.Provincia = request.Provincia;
                entidad.CodigoPostal = request.CodigoPostal;
                entidad.EsConsumidorFinal = request.EsConsumidorFinal;

                await _unitOfWork.Clientes.UpdateAsync(entidad);
                await _unitOfWork.CompleteAsync();

                var dto = ClienteMapping.ToResponse(entidad);
                return Ok(Result<ClienteResponse>.Ok(dto, "Cliente actualizado exitosamente"));
            }
            catch (ValidationException vex)
            {
                _logger.LogError(nameof(UpdateCliente), $"Validación al actualizar {id}", vex.Message);
                return UnprocessableEntity(Result<ClienteResponse>.ValidationError(vex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(UpdateCliente), $"Error actualizando {id}", ex.Message);
                return StatusCode(500, Result<ClienteResponse>.Error("Se produjo un error al actualizar el cliente"));
            }



        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                await _unitOfWork.Clientes.SoftDeleteAsync(id);
                await _unitOfWork.CompleteAsync();
                return Ok(Result<string>.Ok("Cliente eliminado"));


            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(DeleteCliente), $"Error eliminando cliente {id}", ex.Message);
                return StatusCode(500, Result<string>.Error("Se produjo un error al eliminar el cliente"));

            }

        }
    }
}
