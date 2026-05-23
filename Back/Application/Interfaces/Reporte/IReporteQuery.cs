using Domain.Entities;

namespace Application.Interfaces
{
    public interface IReporteQuery
    {
        Task<Reporte> GetReporteById(int id);
        Task<List<Reporte>> GetAllReportes();
        Task<List<Reporte>> GetReportesByTipo(string tipo);
    }
}
