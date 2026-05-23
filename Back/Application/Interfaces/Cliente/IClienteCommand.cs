using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Cliente
{
    public interface IClienteCommand
    {
        Task<Domain.Entities.Cliente> CrearCliente(Domain.Entities.Cliente cliente);
        Task<Domain.Entities.Cliente> ModificarCliente(Domain.Entities.Cliente cliente);
        Task EliminarCliente(Domain.Entities.Cliente cliente);
    }
}
