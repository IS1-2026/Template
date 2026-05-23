using Application.DTOs.Request.Reserva;
using Application.Interfaces.Reserva;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaServices _service;

        public ReservaController(IReservaServices service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CrearReserva([FromBody] CrearReservaRequest request)
        {
            Console.WriteLine(request.Fecha);
            var response = await _service.CrearReserva(request);
            return CreatedAtAction(nameof(ConsultarReserva), new { reservaId = response.ReservaId }, response);
        }

        [HttpGet("{reservaId}")]
        public async Task<IActionResult> ConsultarReserva(int reservaId)
        {
            var response = await _service.ConsultarReserva(reservaId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ListarReservas()
        {
            var response = await _service.ListarReservas();
            return Ok(response);
        }
        [HttpGet("{dni}/reservas")]
        public async Task<IActionResult> ListarReservasPorDni(int dni)
        {
            var response = await _service.ListarReservasPorDni(dni);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> ModificarReserva([FromBody] ActualizarReservaRequest request)
        {
            var response = await _service.ModificarReserva(request);
            return Ok(response);
        }

        [HttpDelete("{reservaId}")]
        public async Task<IActionResult> EliminarReserva(int reservaId)
        {
            var response = await _service.EliminarReserva(reservaId);
            return Ok(response);
        }
    }
}