using Application.Interfaces.Competencias;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Competencias;


namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TorneoController : ControllerBase
    {
        private readonly ITorneoService _serviceTorneo;
        public TorneoController(ITorneoService serviceTorneo)
        {
            _serviceTorneo = serviceTorneo;
        }

        [HttpPost("GenerarFixture")]
        public async Task<IActionResult> GenerarFixture(int idTorneo, CancellationToken ct)
        {
            await _serviceTorneo.GenerarFixture(idTorneo, ct);
            return NoContent();
        }

        [HttpPut("AgregarResultado")]
        public async Task<IActionResult> CargarResultado(int idPartido, int golesLocal, int golesVis, CancellationToken ct)
        {
            await _serviceTorneo.CargarResultado(idPartido, golesLocal, golesVis, ct);
            return NoContent();
        }
    }
}