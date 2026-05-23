using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCases
{
    public class ReporteService : IReporteService
    {
        private readonly IReporteCommand _command;
        private readonly IReporteQuery _query;

        public ReporteService(IReporteCommand command, IReporteQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<ReporteResponse> CreateReporte(ReporteRequest request)
        {
            var tiposValidos = new[] { "Ingresos", "Asistencia", "Reservas" };
            if (!tiposValidos.Contains(request.TipoReporte))
                throw new ExceptionBadRequest($"TipoReporte debe ser uno de: {string.Join(", ", tiposValidos)}");

            var reporte = new Reporte
            {
                TipoReporte = request.TipoReporte,
                FechaEmision = DateTime.Now
            };

            var result = await _command.CreateReporte(reporte);

            return new ReporteResponse
            {
                ReporteId = result.IdReporte,
                TipoReporte = result.TipoReporte,
                FechaEmision = result.FechaEmision
            };
        }

        public async Task<ReporteResponse> UpdateReporte(ReporteRequest request, int id)
        {
            var existente = await _query.GetReporteById(id);
            if (existente == null)
                throw new ExceptionNotFound($"No se encontró el reporte con Id {id}");

            var tiposValidos = new[] { "Ingresos", "Asistencia", "Reservas" };
            if (!tiposValidos.Contains(request.TipoReporte))
                throw new ExceptionBadRequest($"TipoReporte debe ser uno de: {string.Join(", ", tiposValidos)}");

            var result = await _command.UpdateReporte(request, id);

            return new ReporteResponse
            {
                ReporteId = result.IdReporte,
                TipoReporte = result.TipoReporte,
                FechaEmision = result.FechaEmision
            };
        }

        public async Task<ReporteResponse> GetReporteById(int id)
        {
            var reporte = await _query.GetReporteById(id);
            if (reporte == null)
                throw new ExceptionNotFound($"No se encontró el reporte con Id {id}");

            return new ReporteResponse
            {
                ReporteId = reporte.IdReporte,
                TipoReporte = reporte.TipoReporte,
                FechaEmision = reporte.FechaEmision
            };
        }

        public async Task<List<ReporteResponse>> GetAllReportes()
        {
            var reportes = await _query.GetAllReportes();
            return reportes.Select(r => new ReporteResponse
            {
                ReporteId = r.IdReporte,
                TipoReporte = r.TipoReporte,
                FechaEmision = r.FechaEmision
            }).ToList();
        }

        public async Task<List<ReporteResponse>> GetReportesByTipo(string tipo)
        {
            var tiposValidos = new[] { "Ingresos", "Asistencia", "Reservas" };
            if (!tiposValidos.Contains(tipo))
                throw new ExceptionBadRequest($"TipoReporte debe ser uno de: {string.Join(", ", tiposValidos)}");

            var reportes = await _query.GetReportesByTipo(tipo);
            return reportes.Select(r => new ReporteResponse
            {
                ReporteId = r.IdReporte,
                TipoReporte = r.TipoReporte,
                FechaEmision = r.FechaEmision
            }).ToList();
        }

        public async Task<ReporteResponse> DeleteReporte(int id)
        {
            var existente = await _query.GetReporteById(id);
            if (existente == null)
                throw new ExceptionNotFound($"No se encontró el reporte con Id {id}");

            var result = await _command.DeleteReporte(id);

            return new ReporteResponse
            {
                ReporteId = result.IdReporte,
                TipoReporte = result.TipoReporte,
                FechaEmision = result.FechaEmision
            };
        }
    }
}
