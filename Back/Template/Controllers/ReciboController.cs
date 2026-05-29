using Application.DTOs.Request.Recibo;
using Application.DTOs.Response.Recibo;
using Application.Interfaces.Recibo;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReciboController : ControllerBase
    {
        private readonly IReciboService _service;

        public ReciboController(IReciboService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarRecibo([FromBody] RegistrarReciboRequest request, CancellationToken ct)
        {
            var response = await _service.RegistrarRecibo(request, ct);

            // Retorna un 201 Created y expone la ruta para consultar este recibo específico
            return CreatedAtAction(nameof(ConsultarRecibo), new { idRecibo = response.Id_Recibo }, response);
        }

        [HttpGet("{idRecibo}")]
        public async Task<IActionResult> ConsultarRecibo(int idRecibo, CancellationToken ct)
        {
            var response = await _service.ConsultarRecibo(idRecibo, ct);
            return Ok(response);
        }

        // Endpoint específico para Imprimir: api/v1/Recibo/5/imprimir
        // Así evitamos la colisión de rutas (el warning que solucionamos en Entrenamiento)
        [HttpGet("{idRecibo}/imprimir")]
        public async Task<IActionResult> ImprimirRecibo(int idRecibo, CancellationToken ct)
        {
            var response = await _service.ImprimirRecibo(idRecibo, ct);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> ModificarRecibo([FromBody] ModificarReciboRequest request, CancellationToken ct)
        {
            var response = await _service.ModificarRecibo(request, ct);
            return Ok(response);
        }

        [HttpDelete("{idRecibo}")]
        public async Task<IActionResult> EliminarRecibo(int idRecibo, CancellationToken ct)
        {
            // Mapeamos el id de la ruta al DTO que espera la lógica del servicio
            var request = new EliminarReciboRequest { Id_Recibo = idRecibo };
            var response = await _service.EliminarRecibo(request, ct);
            return Ok(response);
        }
    }
}