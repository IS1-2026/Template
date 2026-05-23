using Application.Interfaces.Cliente;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class ClienteQuery:IClienteQuery
    {
        private readonly AppDbContext _context;

        //Constructor
        public ClienteQuery (AppDbContext context)
        {
            _context = context;
        }


        //Busco cliente por dni
        public async Task<Cliente> ConsultarCliente(int dni)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(c => c.Dni == dni);
        }

        //Traigo todos los cl
        public async Task<List<Cliente>> ListarClientes()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<Cliente> ConsultarClientePorEmail(string correo,CancellationToken ct = default)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c=> c.Correo==correo,ct);
        }
    }
}
