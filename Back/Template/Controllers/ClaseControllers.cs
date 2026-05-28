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
            return CreatedAtAction(nameof(ConsultarClase), new { claseId = response.IdClase }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarClase(int id,ModificarClaseRequest request) {
            var response = await _service.ModificarClase(id,request);
            return Ok(response);
        }

        [HttpGet("{claseId}")]
        public async Task<IActionResult> ConsultarClase(int claseId) {

            var response = await _service.ConsultarClase(claseId);
            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> ListarClases()
        {
            var response = await _service.ListarClases();
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarClase(int id)
        {
            var response = await _service.EliminarClase(id);
            return Ok(response);
        }



    }
}
