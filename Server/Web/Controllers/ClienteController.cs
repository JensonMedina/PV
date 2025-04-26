using Application.Common;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly ILoggerApp _logger;

        public ClienteController(IClienteService svc, ILoggerApp _loggerApp)
        {
            _clienteService = svc;
            _logger = _loggerApp;
        }
        [HttpGet]
        public async Task<ActionResult<PagedResponse<ClienteResponse>>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando endpoint GetAll. Intentando Obtener todos");

            try
            {
                var result = await _clienteService.GetClientesAsync(pageNumber, pageSize);
                return Ok(Result<PagedResponse<ClienteResponse>>.Ok(result));

            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {

                    case ExceptionType.NotFound:
                        _logger.LogError(nameof(GetAll), " clientes no  encontrados", ex.Message);
                        return NotFound(Result<object>.NotFound());
                    default:
                        _logger.LogError(nameof(GetAll), "Error inesperado creando cliente", ex.Message);
                        return StatusCode(500, Result<object>.Error());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, Result<object>.Error());


            }

        }
  //---------------------------------------------------------------------------------------------------------------------------------------------------------


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClienteResponse>> GetById([FromRoute] int id)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando endpoint GetById. Intentando Obtener el Id");
            try
            {
                var cliente = await _clienteService.GetClienteByIdAsync(id);
                return Ok(Result<ClienteResponse>.Ok(cliente, "cliente encontrado"));
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                { 
                    case ExceptionType.NotFound:
                        _logger.LogError(nameof(GetById), $"Cliente con el id:{id} no existe", ex.Message);
                        return NotFound(Result<object>.NotFound($"Cliente con el id:{id} no existe"));
                    //case ExceptionType.BadRequest:
                    //    _logger.LogError(nameof(Create), "Id ingresado incorrectamente", ex.Message);
                    //    return BadRequest(Result<object>.BadRequest());
                    default:
                        _logger.LogError(nameof(GetById), "Error inesperado creando cliente", ex.Message);
                        return StatusCode(500, Result<object>.Error());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, Result<object>.Error());
            }

        }
 //---------------------------------------------------------------------------------------------------------------------------------------------------------

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ClienteRequest clienteRequest)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Create)}";

            try
            {
                _logger.LogInfo(contexto, "iniciando metodo");
                await _clienteService.CreateClienteAsync(clienteRequest);
                _logger.LogInfo(contexto, "Finalizado");
                return Ok(Result<object>.Ok());
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {

                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, ex.Message);

                        return NotFound(Result<object>.NotFound());
                    default:
                        _logger.LogError(contexto, "Error inesperado creando cliente", ex.Message);

                        return StatusCode(500, Result<object>.Error());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, "Error inesperado creando cliente", ex.Message);
                return StatusCode(500, Result<object>.Error());
            }
        }
 //---------------------------------------------------------------------------------------------------------------------------------------------------------

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] ClienteRequest request)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando Update . Intentando Actualizar campos");

            try
            {
                await _clienteService.UpdateClienteAsync(id, request);
                return Ok(Result<object>.Ok());
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {

                    case ExceptionType.NotFound:
                        _logger.LogError(nameof(Update), $"No fue encontrado el cliente con el id: {id}", ex.Message);
                        return NotFound(Result<object>.NotFound());
                    default:
                        _logger.LogError(nameof(Update), "Error inesperado actualizando cliente", ex.Message);
                        return StatusCode(500, Result<object>.Error());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, Result<object>.Error());


            }

        }
//---------------------------------------------------------------------------------------------------------------------------------------------------------
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Delete)}";
            try
            {
                _logger.LogInfo(contexto, "Iniciando");
                await _clienteService.DeleteClienteAsync(id);
                _logger.LogInfo(contexto, "Finalizado");

                return Ok(Result<object>.Ok());
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                { 
                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, ex.Message);

                        return NotFound(Result<object>.NotFound());
                    default:
                        _logger.LogError(contexto, "Error inesperado Eliminando cliente", ex.Message);

                        return StatusCode(500, Result<object>.Error());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, "Error inesperado Eliminando cliente", ex.Message);

                return StatusCode(500, Result<object>.Error());


            }


        }
    }
}
