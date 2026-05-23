using Application.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IReporteCommand
    {
        Task<Reporte> CreateReporte(Reporte reporte);
        Task<Reporte> DeleteReporte(int id);
        Task<Reporte> UpdateReporte(ReporteRequest reporte, int id);
    }
}
