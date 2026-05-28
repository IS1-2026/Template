
using Application.Interfaces.TipoCancha;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class TipoCanchaCommand : ITipoCanchaCommand
    {
        private readonly AppDbContext _context;

        public TipoCanchaCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.TipoCancha> ActualizarTipoCancha(Domain.Entities.TipoCancha TipoCancha, CancellationToken ct = default)
        {
             _context.TiposCancha.Update(TipoCancha);
            await _context.SaveChangesAsync(ct);
            return TipoCancha;
        }

        public async Task<TipoCancha> CrearTipoCancha(TipoCancha TipoCancha, CancellationToken ct = default)
        {
            await _context.TiposCancha.AddAsync(TipoCancha, ct);
            await _context.SaveChangesAsync(ct);
            return TipoCancha;
        }
    }
}
