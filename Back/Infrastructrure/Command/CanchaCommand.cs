
using Application.Interfaces.Cancha;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructrure.Command
{
    public class CanchaCommand : ICanchaCommand
    {
        private readonly AppDbContext _context;

        public CanchaCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cancha> CrearCancha(Cancha Cancha, CancellationToken ct = default)
        {
            await _context.Canchas.AddAsync(Cancha, ct);
            await _context.SaveChangesAsync(ct);
            return Cancha;
        }

        public async Task<Cancha> EliminarCancha(Cancha Cancha, CancellationToken ct = default)
        {
             _context.Remove(Cancha);
            await _context.SaveChangesAsync(ct);
            return Cancha;
        }

        public async Task<Cancha> ModificarCancha(Cancha Cancha, CancellationToken ct = default)
        {
            _context.Canchas.Update(Cancha);
            await _context.SaveChangesAsync(ct);
            return Cancha;
        }
        public async Task<Cancha> CambiarEstado(Cancha Cancha, CancellationToken ct = default)
        {
            _context.Canchas.Update(Cancha);
            await _context.SaveChangesAsync(ct);
            return Cancha;
        }


    }
}
