using Microsoft.AspNetCore.Mvc;
using SM.Application.DTOs;
using SM.Application.Service;
using SM.Domaiin.Interfaces;

namespace ServiceManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TecnicoController : ControllerBase
    {
        private readonly TecnicoService _tecnicoService;

        public TecnicoController(TecnicoService tecnicoService)
        {
            _tecnicoService = tecnicoService;
        }
        [HttpPost]
        public async Task<ActionResult<TecnicoDto>> CreateTecnicoAsync([FromBody] TecnicoCreateDto tecnicoCreateDto)
        {
            if (tecnicoCreateDto == null)
            {
                return BadRequest("Os dados do técnico não podem ser nulos.");
            }
            try
            {
                var tecnicoDto = await _tecnicoService.CreateTecnicoAsync(tecnicoCreateDto);
                var uri = Url.Action(nameof(GetTecnicoByIdAsync), new { id = tecnicoDto.Id });
                return Created(uri, tecnicoDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar técnico: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTecnicoByIdAsync(int id)
        {
            var tecnicoDto = await _tecnicoService.GetTecnicoByIdAsync(id);
            if (tecnicoDto == null)
                return NotFound();
            return Ok(tecnicoDto);
        }
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<TecnicoDto>> GetAllTecnicosAsync()
        {
            var tecnicos = await _tecnicoService.GetAllTecnicoAsync();
            if (tecnicos == null)
                return NoContent();
            return Ok(tecnicos);
        }
        [HttpGet]
        [Route("cpf/{cpf}")]
        public async Task<IActionResult> GetTecnicoByCpfAsync(string cpf)
        {
            var tecnicoDto = await _tecnicoService.GetTecnicoByCpfAsync(cpf);
            if (tecnicoDto == null)
                return NotFound();
            return Ok(tecnicoDto);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTecnicoAsync(int id)
        {
            var tecnicoDto = await _tecnicoService.DeleteTecnicoAsync(id);
            if (tecnicoDto == null)
                return NotFound();
            return Ok(tecnicoDto);
        }
    }
}
