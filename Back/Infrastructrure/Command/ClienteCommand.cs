using Application.Interfaces.Cliente;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class ClienteCommand : IClienteCommand
    {
        private readonly AppDbContext _context;

        public ClienteCommand(AppDbContext context)
        {
            _context = context;
        }

        //Guardo nuevo cl

        public async Task<Cliente> CrearCliente(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);

            await _context.SaveChangesAsync();

            return cliente;
        }


        //Modificar cl

        public async Task<Cliente> ModificarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);

            await _context.SaveChangesAsync();

            return cliente;
        }


        //Borrar un cl

        public async Task EliminarCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);

            await _context.SaveChangesAsync();
        }
    }
}
