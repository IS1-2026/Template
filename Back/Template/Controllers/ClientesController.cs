using Application.DTOs.Request.Cliente;
using Application.Interfaces.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // 1. Crear cliente
        [HttpPost("Registrar")]
        public async Task<IActionResult> CrearCliente([FromBody] CrearClienteRequest request)
        {
            var result = await _clienteService.CrearCliente(request);

            return CreatedAtAction(nameof(ConsultarCliente),new { dni = result.Dni },result);
        }
        //Login 
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _clienteService.Login(request);

            return Ok(result);
        }

        // 2. Consultar cliente
        [HttpGet("{dni}")]
        public async Task<IActionResult> ConsultarCliente(int dni)
        {
            var result = await _clienteService.ConsultarCliente(dni);

            return Ok(result);
        }

        // 3. Modificar cliente
        [HttpPut]
        public async Task<IActionResult> ModificarCliente([FromBody] ActualizarClienteRequest request)
        {
            var result = await _clienteService.ModificarCliente(request);

            return Ok(result);
        }

        // 4. Eliminar cliente
        [HttpDelete("{dni}")]
        public async Task<IActionResult> EliminarCliente(int dni)
        {
            var result = await _clienteService.EliminarCliente(dni);

            return Ok(result);
        }

        // 5. Listar clientes
        [HttpGet]
        public async Task<IActionResult> ListarClientes()
        {
            var result = await _clienteService.ListarClientes();

            return Ok(result);
        }
    }
}