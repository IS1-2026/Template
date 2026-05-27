using Application.DTOs.Request.Administrador;
using Application.DTOs.Request.Asistencia;
using Application.DTOs.Request.Cliente;
using Application.Interfaces.Administrador;
using Application.Interfaces.Asistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorService _service;

        public AdministradorController(IAdministradorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarAdministrador([FromBody] CrearAdministradorRequest request)
        {
            var response = await _service.RegistrarAdministrador(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> AdministradorLogin ([FromBody] LoginRequest request)
        {
            var response = await _service.Login(request);
            return Ok(response);
        }

    }
}
