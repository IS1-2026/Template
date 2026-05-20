using Application.DTOs.Request.Cancha;
using Application.Interfaces.Cancha;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CanchaController : ControllerBase
    {
        private readonly ICanchaService _service;

        public CanchaController(ICanchaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCancha([FromBody] CrearCanchaRequest request)
        {
            var response = await _service.CrearCancha(request);
            return CreatedAtAction(nameof(ConsultarCancha), new { CanchaId = response.IdCancha }, response);
        }

        [HttpGet("{canchaId}")]
        public async Task<IActionResult> ConsultarCancha([FromRoute]int canchaId)
        {
            var response = await _service.ConsultarCancha(canchaId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ListarCanchas() 
        {
            var response = await _service.ListarCanchas();
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> ModificarCancha([FromBody] ActualizarCanchaRequest request)
        {
            var response = await _service.ModificarCancha(request);
            return Ok(response);
        }

        [HttpPatch("{canchaId}/estado")]
        public async Task<IActionResult> CambiarEstado(int canchaId)
        {
            var response = await _service.CambiarEstado(canchaId);
            return Ok(response);
        }

        [HttpDelete("{canchaId}")]
        public async Task<IActionResult> EliminarCancha(int canchaId)
        {
            var response = await _service.EliminarCancha(canchaId);
            return Ok(response);
        }
    }
}