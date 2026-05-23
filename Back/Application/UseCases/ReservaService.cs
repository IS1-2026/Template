using Application.DTOs.Request.Reserva;
using Application.DTOs.Response.Reserva;
using Application.Exceptions;
using Application.Interfaces.Cancha;
using Application.Interfaces.HorarioCancha;
using Application.Interfaces.Reserva;
using Domain.Entities;

namespace Application.UseCases
{
    public class ReservaService : IReservaServices
    {
        private readonly IReservaCommand _reservaCommand;
        private readonly IReservaQuery _reservaQuery;
        private readonly ICanchaQuery _canchaQuery;
        private readonly IHorarioCanchaQuery _horarioCanchaQuery;
        private readonly IHorarioCanchaCommand _horarioCanchaCommand;

        public ReservaService(
            IReservaCommand reservaCommand,
            IReservaQuery reservaQuery,
            ICanchaQuery canchaQuery,
            IHorarioCanchaQuery horarioCanchaQuery,
            IHorarioCanchaCommand horarioCanchaCommand)
        {
            _reservaCommand = reservaCommand;
            _reservaQuery = reservaQuery;
            _canchaQuery = canchaQuery;
            _horarioCanchaQuery= horarioCanchaQuery;
            _horarioCanchaCommand = horarioCanchaCommand;
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

            if (request.IdCanchaHorario <= 0)
            {
                throw new ExceptionBadRequest("Debe ingresar un horario valido");
            }
         

            var horarioCancha = await _horarioCanchaQuery.ConsultarHorarioCancha(request.IdCanchaHorario);
            if (horarioCancha == null)
            {
                throw new ExceptionBadRequest("Debe un horario valido");
            }

            if (horarioCancha.IdCancha!=request.IdCancha)
            {
                throw new ExceptionBadRequest("El horario solicitado no pertenece a la cancha");
            }

            if ( await _reservaQuery.ExisteReserva(request.IdCanchaHorario, request.Fecha))
            {
                throw new ExceptionConflict("El día que intenta reservar ya fue reservado");
            }

            var reserva = new Reserva
            {
                DniCliente = request.DniCliente,
                IdCancha = request.IdCancha,
                IdCanchaHorario = request.IdCanchaHorario,
                MontoTotal = cancha.TipoCancha.Precio,
                Fecha=request.Fecha,
                EsValida = true,
                Cancha = cancha
            };

            var reservaCreada = await _reservaCommand.CrearReserva(reserva);
            return new ReservaResponse
            {
                ReservaId = reservaCreada.IdReserva,
                DniCliente = reservaCreada.DniCliente,
                ReservaHorarioCanchaResponse = new DTOs.Response.HorarioCancha.ReservaHorarioCanchaResponse
                {
                    IdCanchaHorario= horarioCancha.Id,
                    Fecha = reserva.Fecha,
                    HoraInicio= horarioCancha.HoraInicio,
                    HoraFin= horarioCancha.HoraFin,
                },
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
                ReservaHorarioCanchaResponse = new DTOs.Response.HorarioCancha.ReservaHorarioCanchaResponse
                {
                    IdCanchaHorario = reserva.HorarioCancha.Id,
                    Fecha = reserva.Fecha,
                    HoraInicio = reserva.HorarioCancha.HoraInicio,
                    HoraFin = reserva.HorarioCancha.HoraFin,
                },
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
                ReservaHorarioCanchaResponse = new DTOs.Response.HorarioCancha.ReservaHorarioCanchaResponse
                {
                    IdCanchaHorario = r.HorarioCancha.Id,
                    Fecha = r.Fecha,
                    HoraInicio = r.HorarioCancha.HoraInicio,
                    HoraFin = r.HorarioCancha.HoraFin,
                },
                Total = r.MontoTotal
            }).ToList();
        }

        public async Task<ReservaResponse> ModificarReserva(ActualizarReservaRequest request)
        {
            if (request == null)
            {
                throw new ExceptionBadRequest("Debe ingresar datos");
            }

           
            var reserva = await _reservaQuery.ConsultarReserva(request.ReservaId);

            if (reserva == null)
            {
                throw new ExceptionNotFound("Reserva no encontrada");
            }

            if (request.IdHorarioCancha==null)
            {
                throw new ExceptionNotFound("Reserva no encontrada");
            }

            var horarioCancha = await _horarioCanchaQuery.ConsultarHorarioCancha(request.IdHorarioCancha);

            reserva.IdCanchaHorario = request.IdHorarioCancha;

            var reservaActualizada = await _reservaCommand.ModificarReserva(reserva);

            return new ReservaResponse
            {
                ReservaId = reservaActualizada.IdReserva,
                DniCliente = reservaActualizada.DniCliente,
                ReservaHorarioCanchaResponse = new DTOs.Response.HorarioCancha.ReservaHorarioCanchaResponse
                {
                    IdCanchaHorario = horarioCancha.Id,
                    Fecha = reservaActualizada.Fecha,
                    HoraInicio = horarioCancha.HoraInicio,
                    HoraFin = horarioCancha.HoraFin,
                },
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
                ReservaId = reserva.IdReserva,
                DniCliente = reserva.DniCliente,
                ReservaHorarioCanchaResponse = new DTOs.Response.HorarioCancha.ReservaHorarioCanchaResponse
                {
                    IdCanchaHorario = reserva.HorarioCancha.Id,
                    Fecha = reserva.Fecha,
                    HoraInicio = reserva.HorarioCancha.HoraInicio,
                    HoraFin = reserva.HorarioCancha.HoraFin,
                },
                Total = reserva.MontoTotal
            };
        }
    }
}