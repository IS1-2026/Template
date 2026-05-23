using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructrure.Query
{
    public class ReporteQuery : IReporteQuery
    {
        private readonly AppDbContext _context;

        public ReporteQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Reporte> GetReporteById(int id)
        {
            return await _context.Reportes.FirstOrDefaultAsync(r => r.IdReporte == id);
        }

        public async Task<List<Reporte>> GetAllReportes()
        {
            return await _context.Reportes.ToListAsync();
        }

        public async Task<List<Reporte>> GetReportesByTipo(string tipo)
        {
            return await _context.Reportes
                .Where(r => r.TipoReporte == tipo)
                .ToListAsync();
        }
    }
}
