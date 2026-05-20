

using Application.Interfaces.Cancha;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class CanchaQuery : ICanchaQuery
    {
        private readonly AppDbContext _context;

        public CanchaQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cancha> ConsultarCancha(int CanchaId, CancellationToken ct = default)
        {
            return await _context.Canchas.Include(c=>c.TipoCancha).FirstOrDefaultAsync(c=>c.IdCancha==CanchaId,ct);
        }

        public async Task<List<Cancha>> ListarCanchas(CancellationToken ct = default)
        {
            return await _context.Canchas.Include(c=>c.TipoCancha).ToListAsync(ct);
        }
    }
}
