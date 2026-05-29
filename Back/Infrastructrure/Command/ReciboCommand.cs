using Application.Interfaces.Recibo;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class ReciboCommand : IReciboCommand
    {
        private readonly AppDbContext _context;

        public ReciboCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Recibo> RegistrarRecibo(Recibo recibo, CancellationToken ct = default)
        {
            await _context.Set<Recibo>().AddAsync(recibo, ct); // O '_context.Recibos.AddAsync' si está declarada la propiedad
            await _context.SaveChangesAsync(ct);
            return recibo;
        }

        public async Task<Recibo> ModificarRecibo(Recibo recibo, CancellationToken ct = default)
        {
            _context.Set<Recibo>().Update(recibo);
            await _context.SaveChangesAsync(ct);
            return recibo;
        }

        public async Task<Recibo> EliminarRecibo(Recibo recibo, CancellationToken ct = default)
        {
            _context.Set<Recibo>().Remove(recibo);
            await _context.SaveChangesAsync(ct);
            return recibo;
        }
    }
}
