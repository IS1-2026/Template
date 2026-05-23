using Application.DTOs.Request.TipoCancha;
using Application.Interfaces.TipoCancha;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TipoCanchaController : ControllerBase
    {
        private readonly ITipoCanchaService _service;

        public TipoCanchaController(ITipoCanchaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CrearTipoCancha([FromBody] CrearTipoCanchaRequest request)
        {
            var response = await _service.CrearTipoCancha(request);
            return CreatedAtAction(nameof(CrearTipoCancha), new { id = response.Id }, response);
        }

        [HttpGet]
        public async Task<IActionResult> ListarCanchas()
        {
            var result = await _service.ListarTipoCancha();
            return Ok(result);
        }
    }
}