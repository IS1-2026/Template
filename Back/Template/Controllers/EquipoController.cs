using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Equipos;
using Application.DTOs.Request.Equipos;
using Application.DTOs.Response.Equipos;


namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly IEquipoService _service;
        public EquipoController(IEquipoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CrearEquipo([FromBody] CrearEquipoRequest request, CancellationToken ct)
        {
            var response = await _service.CrearEquipo(request, ct);
            return CreatedAtAction(nameof(ConsultarEquipo), new { IdEquipo = response }, response);
        }

        [HttpGet("{IdEquipo}")]
        public async Task<IActionResult> ConsultarEquipo(int IdEquipo, CancellationToken ct)
        {
            var response = await _service.ObtenerEquipoPorId(IdEquipo, ct);
            return Ok(response);
        }

        [HttpPut("{IdEquipo}")]
        public async Task<IActionResult> ModificarEquipo([FromBody] ModificarEquipoRequest request, CancellationToken ct)
        {
            await _service.ModificarEquipo(request, ct);
            return NoContent();
        }

        [HttpDelete("{IdEquipo}")]
        public async Task<IActionResult> EliminarEquipo(int IdEquipo)
        {
            await _service.EliminarEquipo(IdEquipo);
            return NoContent();
        }
    }
}
