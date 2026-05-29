using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCases
{
    public class DescuentoService : IDescuentoService
    {
        private readonly IDescuentoCommand _command;
        private readonly IDescuentoQuery _query;

        public DescuentoService(IDescuentoCommand command, IDescuentoQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<DescuentoResponse> CreateDescuento(CrearDescuentoRequest request)
        {
            var tiposValidos = new[] { "Reserva", "Inscripcion", "General" };
            if (!tiposValidos.Contains(request.TipoDescuento))
                throw new ExceptionBadRequest($"TipoDescuento debe ser uno de: {string.Join(", ", tiposValidos)}");

            if (request.Valor <= 0 || request.Valor > 100)
                throw new ExceptionBadRequest("El valor del descuento debe estar entre 1 y 100.");

            if (request.FechaFin <= request.FechaInicio)
                throw new ExceptionBadRequest("La fecha de fin debe ser posterior a la fecha de inicio.");

            var descuento = new Descuento
            {
                Valor = request.Valor,
                Descripcion = request.Descripcion,
                FechaInicio = request.FechaInicio,
                FechaFin = request.FechaFin,
                TipoDescuento = request.TipoDescuento,
                Activo = true
            };

            var result = await _command.CrearDescuento(descuento);
            return MapToResponse(result);
        }

        public async Task<DescuentoResponse> UpdateDescuento(ModificarDescuentoRequest request, int id)
        {
            var descuento = await _query.GetDescuentoById(id);
            if (descuento == null)
                throw new ExceptionNotFound($"No se encontró el descuento con Id {id}");

            var tiposValidos = new[] { "Reserva", "Inscripcion", "General" };
            if (!tiposValidos.Contains(request.TipoDescuento))
                throw new ExceptionBadRequest($"TipoDescuento debe ser uno de: {string.Join(", ", tiposValidos)}");

            descuento.Valor = request.Valor;
            descuento.Descripcion = request.Descripcion;
            descuento.FechaInicio = request.FechaInicio;
            descuento.FechaFin = request.FechaFin;
            descuento.TipoDescuento = request.TipoDescuento;
            descuento.Activo = request.Activo;

            var result = await _command.ModificarDescuento(descuento);
            return MapToResponse(result);
        }

        public async Task<DescuentoResponse> GetDescuentoById(int id)
        {
            var descuento = await _query.GetDescuentoById(id);
            if (descuento == null)
                throw new ExceptionNotFound($"No se encontró el descuento con Id {id}");

            return MapToResponse(descuento);
        }

        public async Task<List<DescuentoResponse>> GetAllDescuentos()
        {
            var descuentos = await _query.GetAllDescuentos();
            return descuentos.Select(MapToResponse).ToList();
        }

        public async Task<DescuentoResponse> DeleteDescuento(int id)
        {
            var descuento = await _query.GetDescuentoById(id);
            if (descuento == null)
                throw new ExceptionNotFound($"No se encontró el descuento con Id {id}");

            var result = await _command.EliminarDescuento(descuento);
            return MapToResponse(result);
        }

        public async Task<DescuentoResponse> GetDescuentoActivoPorTipo(string tipo)
        {
            var descuento = await _query.GetDescuentoActivoPorTipo(tipo);
            if (descuento == null)
                throw new ExceptionNotFound($"No hay descuento activo para el tipo '{tipo}'");

            return MapToResponse(descuento);
        }

        private DescuentoResponse MapToResponse(Descuento d) => new DescuentoResponse
        {
            IdDescuento = d.IdDescuento,
            Valor = d.Valor,
            Descripcion = d.Descripcion,
            FechaInicio = d.FechaInicio,
            FechaFin = d.FechaFin,
            TipoDescuento = d.TipoDescuento,
            Activo = d.Activo
        };
    }
}
