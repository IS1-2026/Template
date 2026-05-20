using Application.DTOs.Request.Entrenamiento;
using Application.DTOs.Request.Reserva;
using Application.Interfaces.Entrenamiento;
using Application.Interfaces.Reserva;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EntrenamientoController : ControllerBase
    {
        private readonly IEntrenamientoService _service;
        public EntrenamientoController(IEntrenamientoService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> ProgramarEntrenamiento([FromBody] ProgramarEntrenamientoRequest request)
        {
            var response = await _service.ProgramarEntrenamiento(request);
            return CreatedAtAction(nameof(ConsultarEntrenamiento), new { EntrenamientoId = response.Id_Entrenamiento }, response);
        }



        [HttpGet("{IdEntrenamiento}")]
        public async Task<IActionResult> ConsultarEntrenamiento(int IdEntrenamiento)
        {
            var response = await _service.ConsultarEntrenamiento(IdEntrenamiento);
            return Ok(response);
        }



        [HttpGet("{EntrenamientoId}")]
        public async Task<IActionResult> Entrenamiento(int EntrenamientoId)
        {
            var response = await _service.ImprimirEntrenamiento(EntrenamientoId);
            return Ok(response);
        }



        [HttpPut]
        public async Task<IActionResult> ModificarEntrenamiento([FromBody] ModificarEntrenamientoRequest request)
        {
            var response = await _service.ModificarEntrenamiento(request);
            return Ok(response);
        }





        [HttpDelete("{EntrenamientoId}")]
        public async Task<IActionResult> EliminarEntrenamiento(int EntrenamientoId)
        {
            var response = await _service.EliminarEntrenamiento(EntrenamientoId);
            return Ok(response);
        }
    }
}
