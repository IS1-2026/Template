using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Competencias;
using Application.DTOs.Request.Competencias;


namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompetenciaController : ControllerBase
    {
        private readonly ICompetenciaService _service;
        public CompetenciaController(ICompetenciaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCompetencia([FromBody] CrearCompetenciaRequest request)
        {
            var response = await _service.CrearCompetencia(request);
            return CreatedAtAction(nameof(ConsultarCompetencia), new { IdCompetencia = response }, response);
        }

        [HttpGet("{IdCompetencia}")]
        public async Task<IActionResult> ConsultarCompetencia(int IdCompetencia)
        {
            var response = await _service.ObtenerCompetenciaPorId(IdCompetencia);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> ConsultarCompetencias()
        {
            var response = await _service.ObtenerTodasLasCompetencias();
            return Ok(response);
        }

        [HttpPut("{CompetenciaId}")]
        public async Task<IActionResult> ModificarCompetencia([FromBody] ModificarCompetenciaRequest request)
        {
            await _service.ModificarCompetencia(request);
            return NoContent();
        }

        [HttpDelete("{CompetenciaId}")]
        public async Task<IActionResult> EliminarCompetencia(int CompetenciaId)
        {
            await _service.EliminarCompetencia(CompetenciaId);
            return NoContent();
        }
    }
}
