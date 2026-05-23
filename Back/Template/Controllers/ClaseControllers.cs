using Application.DTOs.Request.Clase;
using Application.Interfaces.Clase;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClaseController : ControllerBase
    {
        private readonly IClaseService _service;
        public ClaseController(IClaseService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> ProgramarClase([FromBody] ProgramarClasesRequest request)
        {
            var response = await _service.ProgramarClase(request);
            return CreatedAtAction(nameof(ConsultarClase), new { IdClase = response.IdClase }, response);
        }

        [HttpPut]
        public async Task<IActionResult> ModificarClase(ModificarClaseRequest request) {
            var response = await _service.ModificarClase(request);
            return Ok(response);
        }

        [HttpGet("{claseId}")]
        public async Task<IActionResult> ConsultarClase(int claseId) {

            var response = await _service.ConsultarClase(claseId);
            return Ok(response);

        }

   

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarClase(int claseId)
        {
            var response = await _service.EliminarClase(claseId);
            return Ok(response);
        }



    }
}
