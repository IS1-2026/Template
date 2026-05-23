using Application.Exceptions;
using Application.Interfaces.HorarioCancha;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class HorarioCanchaQuery : IHorarioCanchaQuery
    {
        private readonly AppDbContext _context;

        public HorarioCanchaQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HorarioCancha> ConsultarHorarioCancha(int IdHorarioCancha, CancellationToken ct = default)
        {
            return await _context.HorarioCancha.FirstOrDefaultAsync(hc => hc.Id == IdHorarioCancha, ct);
        }
    }
}
