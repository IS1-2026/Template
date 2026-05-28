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
            return CreatedAtAction(nameof(ConsultarEntrenamiento), new { Id = response.Id_Entrenamiento }, response);
        }



        [HttpGet("{Id}")]
        public async Task<IActionResult> ConsultarEntrenamiento(int Id)
        {
            var response = await _service.ConsultarEntrenamiento(Id);
            return Ok(response);
        }



        [HttpGet("{EntrenamientoId}/detalle")]
        public async Task<IActionResult> Entrenamiento(int EntrenamientoId)
        {
            var response = await _service.ImprimirEntrenamiento(EntrenamientoId);
            return Ok(response);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarEntrenamiento(int id,[FromBody] ModificarEntrenamientoRequest request)
        {
            var response = await _service.ModificarEntrenamiento(id,request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ListarEntrenamientos()
        {
            var response = await _service.ListarEntrenamientos();
            return Ok(response);
        }
        
        [HttpGet("entrenador/{Entrenadordni}")]
        public async Task<IActionResult> ListarEntrenamientosPorEntrenador(int Entrenadordni)
        {
            var response = await _service.ListarEntrenamientosPorDni(Entrenadordni);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> EliminarEntrenamiento(int Id)
        {
            var response = await _service.EliminarEntrenamiento(Id);
            return Ok(response);
        }
    }
}
