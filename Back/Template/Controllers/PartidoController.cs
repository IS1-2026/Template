using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Partidos;
using Application.DTOs.Request.Partidos;
using Application.DTOs.Response.Partidos;


namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PartidoController : ControllerBase
    {
        private readonly IPartidoService _service;
        public PartidoController(IPartidoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPartido([FromBody] AgregarPartidoRequest request, CancellationToken ct)
        {
            var response = await _service.CrearPartido(request, ct);
            return CreatedAtAction(nameof(ConsultarPartido), new { IdPartido = response }, response);
        }

        [HttpGet("{IdPartido}")]
        public async Task<IActionResult> ConsultarPartido(int IdPartido, CancellationToken ct)
        {
            var response = await _service.ObtenerPartidoPorId(IdPartido, ct);
            return Ok(response);
        }

        [HttpPut("{IdPartido}")]
        public async Task<IActionResult> ModificarPartido([FromBody] ModificarPartidoRequest request, CancellationToken ct)
        {
            await _service.ModificarPartido(request, ct);
            return NoContent();
        }

        [HttpDelete("{IdPartido}")]
        public async Task<IActionResult> EliminarPartido(int IdPartido)
        {
            await _service.EliminarPartido(IdPartido);
            return NoContent();
        }
        [HttpGet("equipo/{IdEquipo}")]
        public async Task<IActionResult> ObtenerPartidoPorEquipo(int IdEquipo)
        {
            var response = await _service.ObtenerPartidoPorEquipo(IdEquipo);
            return Ok(response);
        }
    }
}
