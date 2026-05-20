
using Application.Interfaces.Reserva;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class ReservaQuery : IReservaQuery
    {
        private readonly AppDbContext _context;

        public ReservaQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Reserva> ConsultarReserva(int ReservaId, CancellationToken ct = default)
        {
            return await _context.Reservas.FirstOrDefaultAsync(r => r.IdReserva == ReservaId,ct);
        }

        public async Task<List<Reserva>> ListarReservas(CancellationToken ct = default)
        {
            return await _context.Reservas.ToListAsync(ct);
        }
    }
}
