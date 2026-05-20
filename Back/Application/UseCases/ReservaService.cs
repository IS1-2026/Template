using Application.DTOs.Request.Reserva;
using Application.DTOs.Response.Reserva;
using Application.Exceptions;
using Application.Interfaces.Cancha;
using Application.Interfaces.Reserva;
using Domain.Entities;

namespace Application.UseCases
{
    public class ReservaService : IReservaServices
    {
        private readonly IReservaCommand _reservaCommand;
        private readonly IReservaQuery _reservaQuery;
        private readonly ICanchaQuery _canchaQuery;

        public ReservaService(
            IReservaCommand reservaCommand,
            IReservaQuery reservaQuery,
            ICanchaQuery canchaQuery)
        {
            _reservaCommand = reservaCommand;
            _reservaQuery = reservaQuery;
            _canchaQuery = canchaQuery;
        }

        public async Task<ReservaResponse> CrearReserva(CrearReservaRequest request)
        {
            if (request == null)
            {
                throw new ExceptionBadRequest("Debe ingresar datos");
            }

            if (request.DniCliente <= 0)
            {
                throw new ExceptionBadRequest("Debe ingresar un DNI valido");
            }

            if (request.IdCancha <= 0)
            {
                throw new ExceptionBadRequest("Debe ingresar una cancha valida");
            }
            var cancha = await _canchaQuery.ConsultarCancha(request.IdCancha) ?? throw new ExceptionNotFound("La cancha no existe"); 

            if (request.FechaReserva == DateTime.MinValue)
            {
                throw new ExceptionBadRequest("Debe ingresar una fecha valida");
            }

            if (request.FechaReserva < DateTime.Now)
            {
                throw new ExceptionBadRequest("La fecha de reserva no puede ser menor a la actual");
            }

            var reserva = new Reserva
            {
                DniCliente = request.DniCliente,
                IdCancha = request.IdCancha,
                FechaRes = request.FechaReserva,
                HorarioInicio = request.HorarioInicio,
                HorarioFin = request.HorarioFin,
                MontoTotal = cancha.TipoCancha.Precio,
                Cancha=cancha
            };

            var reservaCreada = await _reservaCommand.CrearReserva(reserva);

            return new ReservaResponse
            {
                ReservaId = reservaCreada.IdReserva,
                DniCliente = reservaCreada.DniCliente,
                IdDescuento = reservaCreada.IdDescuento,
                FechaRes = reservaCreada.FechaRes,
                HoraInicio = reservaCreada.HorarioInicio,
                HoraFin = reservaCreada.HorarioFin,
                Total = reservaCreada.MontoTotal
            };
        }

        public async Task<ReservaResponse> ConsultarReserva(int reservaId)
        {
            if (reservaId <= 0)
            {
                throw new ExceptionBadRequest("Debe ingresar un id valido");
            }

            var reserva = await _reservaQuery.ConsultarReserva(reservaId);

            if (reserva == null)
            {
                throw new ExceptionNotFound("Reserva no encontrada");
            }

            return new ReservaResponse
            {
                ReservaId = reserva.IdReserva,
                DniCliente = reserva.DniCliente,
                IdDescuento = reserva.IdDescuento,
                FechaRes = reserva.FechaRes,
                HoraInicio = reserva.HorarioInicio,
                HoraFin = reserva.HorarioFin,
                Total = reserva.MontoTotal
            };
        }

        public async Task<List<ReservaResponse>> ListarReservas()
        {
            var reservas = await _reservaQuery.ListarReservas();

            return reservas.Select(r => new ReservaResponse
            {
                ReservaId = r.IdReserva,
                DniCliente = r.DniCliente,
                IdDescuento = r.IdDescuento,
                FechaRes = r.FechaRes,
                HoraInicio = r.HorarioInicio,
                HoraFin = r.HorarioFin,
                Total = r.MontoTotal
            }).ToList();
        }

        public async Task<ReservaResponse> ModificarReserva(ActualizarReservaRequest request)
        {
            if (request == null)
            {
                throw new ExceptionBadRequest("Debe ingresar datos");
            }

            if (request.NuevaFecha == DateTime.MinValue)
            {
                throw new ExceptionBadRequest("Debe ingresar una fecha valida");
            }

            if (request.NuevaFecha < DateTime.Now)
            {
                throw new ExceptionBadRequest("La fecha no puede ser menor a la actual");
            }

            var reserva = await _reservaQuery.ConsultarReserva(request.ReservaId);

            if (reserva == null)
            {
                throw new ExceptionNotFound("Reserva no encontrada");
            }

            reserva.FechaRes = request.NuevaFecha;

            var reservaActualizada = await _reservaCommand.ModificarReserva(reserva);

            return new ReservaResponse
            {
                ReservaId = reservaActualizada.IdReserva,
                DniCliente = reservaActualizada.DniCliente,
                IdDescuento = reservaActualizada.IdDescuento,
                FechaRes = reservaActualizada.FechaRes,
                HoraInicio = reservaActualizada.HorarioInicio,
                HoraFin = reservaActualizada.HorarioFin,
                Total = reservaActualizada.MontoTotal
            };
        }

        public async Task<ReservaResponse> EliminarReserva(int reservaId)
        {
            if (reservaId <= 0)
            {
                throw new ExceptionBadRequest("Debe ingresar un id valido");
            }

            var reserva = await _reservaQuery.ConsultarReserva(reservaId);

            if (reserva == null)
            {
                throw new ExceptionNotFound("Reserva no encontrada");
            }

            var reservaEliminada = await _reservaCommand.EliminarReserva(reserva);

            return new ReservaResponse
            {
                ReservaId = reservaEliminada.IdReserva,
                DniCliente = reservaEliminada.DniCliente,
                IdDescuento = reservaEliminada.IdDescuento,
                FechaRes = reservaEliminada.FechaRes,
                HoraInicio = reservaEliminada.HorarioInicio,
                HoraFin = reservaEliminada.HorarioFin,
                Total = reservaEliminada.MontoTotal
            };
        }
    }
}