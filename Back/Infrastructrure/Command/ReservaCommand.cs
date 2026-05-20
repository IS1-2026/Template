

using Application.Interfaces.Reserva;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class ReservaCommand : IReservaCommand
    {
        private readonly AppDbContext _context;

        public ReservaCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Reserva> CrearReserva(Reserva Reserva, CancellationToken ct = default)
        {
            await _context.AddAsync(Reserva, ct);
            await _context.SaveChangesAsync(ct);
            return Reserva;
        }

        public async Task<Reserva> EliminarReserva(Reserva Reserva, CancellationToken ct = default)
        {
            _context.Remove(Reserva);
            await _context.SaveChangesAsync(ct);
            return Reserva;
        }

        public async Task<Reserva> ModificarReserva(Reserva Reserva, CancellationToken ct = default)
        {
            _context.Update(Reserva);
            await _context.SaveChangesAsync(ct);
            return Reserva;
        }
    }
}
