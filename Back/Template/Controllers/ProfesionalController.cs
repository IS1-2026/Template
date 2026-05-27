using Application.DTOs.Request.Cliente;
using Application.DTOs.Request.Profesional;
using Application.Interfaces.Profesionales;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfesionalesController : ControllerBase
    {
        private readonly IProfesionalService _profesionalService;

        public ProfesionalesController(IProfesionalService profesionalService)
        {
            _profesionalService = profesionalService;
        }

        // RF46: REGISTRAR
        [HttpPost("profesores")]
        public async Task<IActionResult> RegistrarProfesor([FromBody] RegistrarProfesorRequest request)
        {
            var resultado = await _profesionalService.RegistrarProfesor(request);
            return CreatedAtAction(nameof(ConsultarPorDni), new { dni = resultado.Dni }, resultado);
        }

        [HttpPost("entrenadores")]
        public async Task<IActionResult> RegistrarEntrenador([FromBody] RegistrarEntrenadorRequest request)
        {
            var resultado = await _profesionalService.RegistrarEntrenador(request);
            return CreatedAtAction(nameof(ConsultarPorDni), new { dni = resultado.Dni }, resultado);
        }

        // RF47: MODIFICAR
        [HttpPatch("profesores/{dni}")]
        public async Task<IActionResult> ModificarProfesor([FromRoute] int dni, [FromBody] RegistrarProfesorRequest request)
        {
            var resultado = await _profesionalService.ModificarProfesor(dni, request);
            return Ok(resultado);
        }

        [HttpPatch("entrenadores/{dni}")]
        public async Task<IActionResult> ModificarEntrenador([FromRoute] int dni, [FromBody] RegistrarEntrenadorRequest request)
        {
            var resultado = await _profesionalService.ModificarEntrenador(dni, request);
            return Ok(resultado);
        }


        [HttpGet("{dni}")]
        public async Task<IActionResult> ConsultarPorDni([FromRoute] int dni)
        {
            try
            {
                var resultado = await _profesionalService.ConsultarProfesorPorDni(dni);
                return Ok(resultado);
            }
            catch
            {
                var resultado = await _profesionalService.ConsultarEntrenadorPorDni(dni);
                return Ok(resultado);
            }
        }

        //RF48: LISTAR TODOS
        [HttpGet]
        public async Task<IActionResult> ConsultarTodos([FromQuery] string tipo)
        {
            if (tipo.ToLower() == "profesor")
            {
                var resultado = await _profesionalService.ConsultarTodosLosProfesores();
                return Ok(resultado);
            }
            else if (tipo.ToLower() == "entrenador")
            {
                var resultado = await _profesionalService.ConsultarTodosLosEntrenadores();
                return Ok(resultado);
            }

            return BadRequest(new { Message = "El tipo de profesional debe ser 'profesor' o 'entrenador'." });
        }

        // RF49: ELIMINAR 
        [HttpDelete("{dni}")]
        public async Task<IActionResult> Eliminar([FromRoute] int dni)
        {
            try
            {
                var resultado = await _profesionalService.EliminarProfesor(dni);
                return Ok(resultado);
            }
            catch
            {
                var resultado = await _profesionalService.EliminarEntrenador(dni);
                return Ok(resultado);
            }
        }

        // RF50: IMPRIMIR (COMO DUPLICA LOGICA LO COMENTO, LO DEJO POR SI SE REQUIERE)
        /*[HttpGet("{dni}/ficha")]
        public async Task<IActionResult> ImprimirFichaProfesional([FromRoute] int dni, [FromQuery] string tipoProfesional)
        {
            var jsonResult = await _profesionalService.ImprimirFichaProfesional(dni, tipoProfesional);
            return Content(jsonResult, "application/json");
        }*/

        // RF51: ASIGNAR PROFESIONALES A CLIENTES
        [HttpPost("asignar-cliente")]
        public async Task<IActionResult> AsignarClienteAProfesional([FromQuery] int profesionalDni, [FromQuery] int clienteId, [FromQuery] double precio)
        {
            var resultado = await _profesionalService.AsignarClienteAProfesional(profesionalDni, clienteId, precio);
            return Ok(resultado);
        }

        // RF52: VERIFICAR CERTIFICACIÓN DEPORTIVA
        [HttpPatch("{dni}/verificar-certificacion")]
        public async Task<IActionResult> VerificarCertificacion([FromRoute] int dni, [FromQuery] string tipoProfesional, [FromQuery] bool aprobado)
        {
            var resultado = await _profesionalService.VerificarCertificacion(dni, tipoProfesional, aprobado);
            return Ok(resultado);
        }
        [HttpPost("login/profesor")]
        public async Task<IActionResult> ProfesorLogin([FromBody] LoginRequest request)
        {
            var response = await _profesionalService.ProfesorLogin(request);
            return Ok(response);
        }
        [HttpPost("login/entrenador")]
        public async Task<IActionResult> AdministradorLogin([FromBody] LoginRequest request)
        {
            var response = await _profesionalService.EntrenadorLogin(request);
            return Ok(response);
        }
    }
}
