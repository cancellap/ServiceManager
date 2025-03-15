using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> CreateClienteAsync([FromBody] ClienteCreateDto clienteCreateDto)
        {
            try
            {
                var clienteDto = await _clienteService.CreateClienteAsync(clienteCreateDto);

                // var uri = Url.Action(nameof(GetClienteByIdAsync), new { id = clienteDto.Id });
                // return Created(uri, clienteDto);
                return Ok(clienteDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
