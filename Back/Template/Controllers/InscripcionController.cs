using Application.DTOs.Request.Inscripcion;
using Application.Interfaces.Incripcion;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class InscripcionController : ControllerBase
    {

        private readonly IInscripcionService _service;
        public InscripcionController ( IInscripcionService service)
        {
            _service= service;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarInscripcion(int id) {
            var response = await _service.ConsultarInscripcion(id);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> AgregarInscripcion([FromBody] AgregarInscripcionRequest request)
        {
            var response = await _service.AgregarInscripcion(request);
            return CreatedAtAction(nameof(ConsultarInscripcion), new { id = response.IdInscripcion }, response);
        }


        [HttpDelete("{inscripcionId}")]
        public async Task<IActionResult> EliminarInscripcion(int inscripcionId)
        {

            var response = await _service.EliminarInscripcion(inscripcionId);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> ListaDeInscriptos() {
            var response = await _service.ListaDeInscriptos();
            return Ok(response);
        }
    }
}
