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



        [HttpGet("dni/{dni}")]
        public async Task<IActionResult> ConsultarInscripcion(int inscripcionId) {
            var response = await _service.ConsultarInscripcion(inscripcionId);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> AgregarInscripcion([FromBody] AgregarInscripcionRequest request)
        {
            var response = await _service.AgregarInscripcion(request);
            return CreatedAtAction(nameof(ConsultarInscripcion), new { IdInscripcion = response.IdInscripcion }, response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarInscripcion(int claseId){

            var response = await _service.EliminarInscripcion(claseId);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> ListaDeInscriptos() {


            var response = await _service.ListaDeInscriptos();
            return Ok(response);
        }













    }
}
