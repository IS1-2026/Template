using Application.DTOs.Request.Cobro;
using Application.DTOs.Response.Cobro;
using Application.Interfaces.Cobro;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CobroController : ControllerBase
    {
        private readonly ICobroService _service;

        public CobroController(ICobroService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarCobro([FromBody] RegistrarCobroRequest request, CancellationToken ct)
        {
            var response = await _service.RegistrarCobro(request, ct);

            // Retorna un 201 Created y le dice al cliente dónde puede consultar el cobro creado
            return CreatedAtAction(nameof(ConsultarCobro), new { idCobro = response.Id_Cobro }, response);
        }

        [HttpGet("{idCobro}")]
        public async Task<IActionResult> ConsultarCobro(int idCobro, CancellationToken ct)
        {
            var response = await _service.ConsultarCobro(idCobro, ct);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> ModificarCobro([FromBody] ModificarCobroRequest request, CancellationToken ct)
        {
            var response = await _service.ModificarCobro(request, ct);
            return Ok(response);
        }

        [HttpDelete("{idCobro}")]
        public async Task<IActionResult> EliminarCobro(int idCobro, CancellationToken ct)
        {
            // Mapeamos el id de la ruta al DTO que espera tu servicio
            var request = new EliminarCobroRequest { Id_Cobro = idCobro };
            var response = await _service.EliminarCobro(request, ct);
            return Ok(response);
        }
    }
}
