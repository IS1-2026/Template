using Application.DTOs.Request.Cliente;
using Application.DTOs.Response.Cliente;

namespace Application.Interfaces.Cliente
{
    public interface IClienteService
    {
        Task<ClienteResponse> CrearCliente(CrearClienteRequest request);
        Task<ClienteResponse> ConsultarCliente(int dni);
        Task<ClienteResponse> ModificarCliente(ActualizarClienteRequest request);
        Task<ClienteResponse> EliminarCliente(int dni);
        Task<List<ClienteResponse>> ListarClientes();
        Task<ClienteShortResponse> Login(LoginRequest request);
    }
}
