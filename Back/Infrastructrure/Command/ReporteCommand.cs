using Application.Interfaces;
using Application.Request;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructrure.Command
{
    public class ReporteCommand : IReporteCommand
    {
        private readonly AppDbContext _context;

        public ReporteCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Reporte> CreateReporte(Reporte reporte)
        {
            _context.Reportes.Add(reporte);
            await _context.SaveChangesAsync();
            return reporte;
        }

        public async Task<Reporte> DeleteReporte(int id)
        {
            var reporteBorrado = await _context.Reportes.FirstOrDefaultAsync(r => r.IdReporte == id);
            _context.Reportes.Remove(reporteBorrado);
            await _context.SaveChangesAsync();
            return reporteBorrado;
        }

        public async Task<Reporte> UpdateReporte(ReporteRequest reporte, int id)
        {
            Reporte reporteUpdated = await _context.Reportes.FirstOrDefaultAsync(r => r.IdReporte == id);
            reporteUpdated.TipoReporte = reporte.TipoReporte;
            await _context.SaveChangesAsync();
            return reporteUpdated;
        }
    }
}
