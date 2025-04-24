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
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService svc)
        {
            _clienteService = svc;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _clienteService.GetClientesAsync(pageNumber, pageSize);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _clienteService.GetClienteByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ClienteRequest _clienteRequest)
        {
            var result = await _clienteService.CreateClienteAsync(_clienteRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, ClienteRequest req)
        {
            var result = await _clienteService.UpdateClienteAsync(id, req);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _clienteService.DeleteClienteAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
