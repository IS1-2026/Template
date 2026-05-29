using Application.Interfaces.Cobro;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class CobroCommand : ICobroCommand
    {
        private readonly AppDbContext _context;

        public CobroCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cobro> RegistrarCobro(Cobro cobro, CancellationToken ct = default)
        {
            await _context.Cobros.AddAsync(cobro, ct);
            await _context.SaveChangesAsync(ct);
            return cobro;
        }

        public async Task<Cobro> ModificarCobro(Cobro cobro, CancellationToken ct = default)
        {
            _context.Cobros.Update(cobro);
            await _context.SaveChangesAsync(ct);
            return cobro;
        }

        public async Task<Cobro> EliminarCobro(Cobro cobro, CancellationToken ct = default)
        {
            _context.Cobros.Remove(cobro);
            await _context.SaveChangesAsync(ct);
            return cobro;
        }
    }
}
