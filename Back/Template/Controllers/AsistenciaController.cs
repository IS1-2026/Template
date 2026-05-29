using Application.DTOs.Request.Asistencia;
using Application.Interfaces.Asistencia;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AsistenciaController : ControllerBase 
    {
        private readonly IAsistenciaService _service;

        public AsistenciaController(IAsistenciaService service)
        {
            _service = service;
        }

        [HttpPost("clase/{claseId}")]
        public async Task<IActionResult> RegistrarAsistencia([FromRoute]int claseId, [FromBody] RegistrarAsistenciaRequest request)
        {
            var response = await _service.RegistrarAsistencia(claseId,request); 
            return CreatedAtAction(nameof(ConsultarAsistencia), new { id = response.IdAsistencia }, response);
        }

        [HttpPut]
        public async Task<IActionResult> ModificarAsistencia([FromBody] ModificarAsistenciaRequest request)
        {
            var response = await _service.ModificarAsistencia(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]  
        public async Task<IActionResult> EliminarAsistencia(int id) 
        {
            var response = await _service.EliminarAsitencia(id);
            return Ok(response);
        }

        [HttpGet("{id}")]  
        public async Task<IActionResult> ConsultarAsistencia(int id) 
        {
            var response = await _service.ConsultarAsistencia(id); 
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ListarAsistencia([FromQuery] int idClase) 
        {
            var response = await _service.ListarAsistencia(idClase); 
            return Ok(response);
        }


        [HttpPatch("{id}/asistencia")] 
        public async Task<IActionResult> PasarAsistencia([FromBody] ModificarAsistenciaRequest request)
        {
            var response = await _service.PasarAsistencia(request);
            return Ok(response);
        }
    }
}