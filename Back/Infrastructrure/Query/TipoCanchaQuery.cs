using Application.Interfaces.TipoCancha;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class TipoCanchaQuery : ITipoCanchaQuery
    {
        private readonly AppDbContext _context;

        public TipoCanchaQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExisteTipoCancha(int id, CancellationToken ct = default)
        {
            return await _context.TiposCancha.AnyAsync(t => t.IdTipoCancha == id, ct);
        }

        public async Task<List<TipoCancha>> ListarTipoCanchas(CancellationToken ct = default)
        {
            return await _context.TiposCancha.ToListAsync(ct);
        }

        public async Task<TipoCancha> ObtenerTipoCancha(int id, CancellationToken ct = default)
        {
            return await _context.TiposCancha.FirstOrDefaultAsync(t => t.IdTipoCancha == id, ct);
        }
    }
}
