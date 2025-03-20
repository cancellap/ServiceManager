using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using SM.Application.DTOs;
using SM.Application.Service;

namespace ServiceManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDto>> CreateClienteAsync([FromBody] ClienteCreateDto clienteCreateDto)
        {
            if (clienteCreateDto == null)
            {
                return BadRequest("Os dados do cliente não podem ser nulos.");
            }

            try
            {
                var clienteDto = await _clienteService.CreateClienteAsync(clienteCreateDto);

                var uri = Url.Action(nameof(GetClienteByIdAsync), new { id = clienteDto.Id });
                return Created(uri, clienteDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar cliente: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<ClienteDto>> GetAllClientesAsync()
        {
            var clientes = await _clienteService.GetAllClientesAsync();
            if (clientes == null)
                return NoContent();
            return Ok(clientes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetClienteByIdAsync(int id)
        {
            var clienteDto = await _clienteService.GetClienteByIdAsync(id);
            if (clienteDto == null)
                return NotFound();
            return Ok(clienteDto);
        }

        [HttpGet]
        [Route("cnpj/{cnpj}")]
        public async Task<IActionResult> GetClienteByCnpjAsync(string cnpj)
        {
            var clienteDto = await _clienteService.GetClienteByCnpjAsync(cnpj);
            if (clienteDto == null)
                return NotFound();
            return Ok(clienteDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteClienteAsync(int id)
        {
            try
            {
                var clienteDto = await _clienteService.DeleteClienteAsync(id);
                return Ok(clienteDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao deletar cliente: {ex.Message}");
            }
        }
    }
}
