using Application.Common;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("v1/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly ILoggerApp _logger;

        public ClienteController(IClienteService clienteService, ILoggerApp _loggerApp)
        {
            _clienteService = clienteService;
            _logger = _loggerApp;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<PagedResponse<ClienteResponse>>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] int negocioId = 0, [FromQuery] bool onlyActive = true)
        {
            string contexto = $"{GetType().Name} - {nameof(GetAll)}";
            _logger.LogInfo(contexto, "Iniciando método GetAll");

            try
            {
                var result = await _clienteService.GetAll(
                    pageNumber,
                    pageSize,
                    onlyActive,
                    negocioId);

                _logger.LogInfo(contexto, $"GetAll finalizado. Total registros: {result.TotalItems}");
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

        [HttpGet("{id}")]
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
                var cliente = await _clienteService.GetById(id);
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

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] ClienteRequest request)
        {
            string contexto = $"{GetType().Name} - {nameof(Register)}";
            _logger.LogInfo(contexto, "Iniciando método Create");

            try
            {
                await _clienteService.Register(request);
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
        [HttpPut("modify")]
        public async Task<ActionResult> Modify([FromQuery] int id, [FromBody] ClienteModifyRequest request)
        {
            string contexto = $"{GetType().Name} - {nameof(Modify)}";
            _logger.LogInfo(contexto, "Iniciando método Update");

            try
            {
                await _clienteService.Modify(id, request);
                _logger.LogInfo(contexto, $"Update finalizado. Id:{id}");
                return Ok(Result<object>.Ok());
            }
            catch (ExceptionApp ex)
            {
                _logger.LogError(contexto, ex.Message);
                return ex.Type switch
                {
                    ExceptionType.NotFound => NotFound(Result<object>.NotFound(ex.Message)),
                    ExceptionType.Conflict => Conflict(Result<object>.Conflict(ex.Message)),
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
        [HttpDelete("disable")]
        public async Task<ActionResult> Disable([FromQuery] int id, [FromQuery] int negocioId)
        {
            string contexto = $"{GetType().Name} - {nameof(Disable)}";
            _logger.LogInfo(contexto, "Iniciando método Delete");

            try
            {
                await _clienteService.Disable(id, negocioId);
                _logger.LogInfo(contexto, $"Delete finalizado. Id:{id} (Negocio:{negocioId})");
                return Ok(Result<object>.Ok());
            }
            catch (ExceptionApp ex)
            {
                _logger.LogError(contexto, ex.Message);
                return ex.Type switch
                {
                    ExceptionType.BadRequest => BadRequest(Result<object>.BadRequest(ex.Message)),
                    ExceptionType.NotFound => NotFound(Result<object>.NotFound(ex.Message)),
                    ExceptionType.Forbidden => StatusCode(403, Result<object>.Forbidden(ex.Message)),
                    _ => StatusCode(500, Result<object>.Error(ex.Message))
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado Delete. Error: {ex.Message}");
                return StatusCode(500, Result<object>.Error());
            }
        }
    }
}
