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
        [HttpGet]
        public async Task<ActionResult<PagedResponse<ClienteResponse>>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] int negocioId = 0)
        {
            string contexto = $"{GetType().Name} - {nameof(GetAll)}";
            _logger.LogInfo(contexto, "Iniciando método GetAll");

            try
            {
                var result = await _clienteService.GetClientesAsync(
                    pageNumber,
                    pageSize,
                    onlyActive: true,
                    negocioId);

                _logger.LogInfo(contexto, $"GetAll finalizado. Total registros: {result.TotalCount}");
                return Ok(Result<PagedResponse<ClienteResponse>>.Ok(result));
            }
            catch (ExceptionApp ex)
            {
                _logger.LogError(contexto, ex.Message);
                return ex.Type switch
                {
                    ExceptionType.BadRequest => BadRequest(Result<object>.BadRequest(ex.Message)),
                    ExceptionType.NotFound => NotFound(Result<object>.NotFound(ex.Message)),
                    _ => StatusCode(500, Result<object>.Error(ex.Message))
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado GetAll. Error: {ex.Message}");
                return StatusCode(500, Result<object>.Error());
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClienteResponse>> GetById([FromRoute] int id)
        {
            string contexto = $"{GetType().Name} - {nameof(GetById)}";
            _logger.LogInfo(contexto, "Iniciando método GetById");

            if (id <= 0)
            {
                var msg = "Id debe ser mayor que cero";
                _logger.LogError(contexto, msg);
                return BadRequest(Result<object>.BadRequest(msg));
            }

            try
            {
                var cliente = await _clienteService.GetClienteByIdAsync(id);
                _logger.LogInfo(contexto, $"GetById finalizado. Id:{id}");
                return Ok(Result<ClienteResponse>.Ok(cliente));
            }
            catch (ExceptionApp ex)
            {
                _logger.LogError(contexto, ex.Message);
                return ex.Type switch
                {
                    ExceptionType.BadRequest => BadRequest(Result<object>.BadRequest(ex.Message)),
                    ExceptionType.NotFound => NotFound(Result<object>.NotFound(ex.Message)),
                    _ => StatusCode(500, Result<object>.Error(ex.Message))
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado GetById. Error: {ex.Message}");
                return StatusCode(500, Result<object>.Error());
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ClienteRequest request)
        {
            string contexto = $"{GetType().Name} - {nameof(Create)}";
            _logger.LogInfo(contexto, "Iniciando método Create");

            try
            {
                await _clienteService.CreateClienteAsync(request);
                _logger.LogInfo(contexto, "Create finalizado");
                return Ok(Result<object>.Ok());
            }
            catch (ExceptionApp ex)
            {
                _logger.LogError(contexto, ex.Message);
                return ex.Type switch
                {
                    ExceptionType.ValidationError => BadRequest(Result<object>.BadRequest(ex.Message)),
                    ExceptionType.Conflict => Conflict(Result<object>.Conflict(ex.Message)),
                    ExceptionType.Unauthorized => StatusCode(401, Result<object>.Unauthorized(ex.Message)),
                    _ => BadRequest(Result<object>.BadRequest(ex.Message))
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado Create. Error: {ex.Message}");
                return StatusCode(500, Result<object>.Error());
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] ClienteRequest request)
        {
            string contexto = $"{GetType().Name} - {nameof(Update)}";
            _logger.LogInfo(contexto, "Iniciando método Update");
            try
            {
                await _clienteService.UpdateClienteAsync(id, request);
                _logger.LogInfo(contexto, $"Update finalizado. Id:{id}");
                return Ok(Result<object>.Ok());
            }
            catch (ExceptionApp ex)
            {
                _logger.LogError(contexto, ex.Message);
                return ex.Type switch
                {
                    ExceptionType.NotFound => NotFound(Result<object>.NotFound(ex.Message)),
                    ExceptionType.ValidationError => BadRequest(Result<object>.BadRequest(ex.Message)),
                    _ => BadRequest(Result<object>.BadRequest(ex.Message))
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado Update. Error: {ex.Message}");
                return StatusCode(500, Result<object>.Error());
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            string contexto = $"{GetType().Name} - {nameof(Delete)}";
            _logger.LogInfo(contexto, "Iniciando método Delete");
            try
            {
                await _clienteService.DeleteClienteAsync(id);
                _logger.LogInfo(contexto, $"Delete finalizado. Id:{id}");
                return Ok(Result<object>.Ok());
            }
            catch (ExceptionApp ex)
            {
                _logger.LogError(contexto, ex.Message);
                return ex.Type == ExceptionType.NotFound ? NotFound(Result<object>.NotFound()) : StatusCode(500, Result<object>.Error());
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado Delete. Error: {ex.Message}");
                return StatusCode(500, Result<object>.Error());
            }
        }
    }
}
