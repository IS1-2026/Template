using Application.Request;
using Application.Response;

namespace Application.Interfaces
{
    public interface IReporteService
    {
        Task<ReporteResponse> CreateReporte(ReporteRequest request);
        Task<ReporteResponse> UpdateReporte(ReporteRequest request, int id);
        Task<ReporteResponse> GetReporteById(int id);
        Task<List<ReporteResponse>> GetAllReportes();
        Task<List<ReporteResponse>> GetReportesByTipo(string tipo);
        Task<ReporteResponse> DeleteReporte(int id);
    }
}
