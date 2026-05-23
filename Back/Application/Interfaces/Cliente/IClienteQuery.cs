using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Cliente
{
    public interface IClienteQuery
    {
        Task<Domain.Entities.Cliente> ConsultarCliente(int dni);

        Task<List<Domain.Entities.Cliente>> ListarClientes();
        Task<Domain.Entities.Cliente> ConsultarClientePorEmail(string correo, CancellationToken ct = default);

    }
}
