using Application.DTOs.Request.Cancha;
using Application.DTOs.Request.HorarioCancha;
using Application.DTOs.Response;
using Application.DTOs.Response.Cancha;
using Application.DTOs.Response.HorarioCancha;
using Application.Exceptions;
using Application.Interfaces.Cancha;
using Application.Interfaces.HorarioCancha;
using Application.Interfaces.Reserva;
using Application.Interfaces.TipoCancha;
using Domain.Entities;

namespace Application.UseCases
{
    public class CanchaService : ICanchaService
    {
        private readonly ICanchaCommand _canchaCommand;
        private readonly ICanchaQuery _canchaQuery;
        private readonly ITipoCanchaQuery _tipoCanchaQuery;
        private readonly IHorarioCanchaService _horarioCanchaService;
        private readonly IReservaQuery _reservaQuery;

        public CanchaService(ICanchaCommand canchaCommand, ICanchaQuery canchaQuery, ITipoCanchaQuery tipoCanchaQuery,
            IHorarioCanchaService horarioCanchaService,IReservaQuery reservaQuery)
        {
            _canchaCommand = canchaCommand;
            _canchaQuery = canchaQuery;
            _tipoCanchaQuery = tipoCanchaQuery;
            _horarioCanchaService= horarioCanchaService;
            _reservaQuery = reservaQuery;
        }

        public async Task<CanchaResponse> CrearCancha(CrearCanchaRequest request)
        {
            if (request.IdTipoCancha <= 0)
            {
                throw new ExceptionBadRequest("Ingrese un id válido");
            }
            if (String.IsNullOrEmpty(request.Nombre) || request.Nombre.Length>20) 
            {
                throw new ExceptionBadRequest("Ingrese un nombre valido");
            }

           var tipoCancha = await _tipoCanchaQuery.ObtenerTipoCancha(request.IdTipoCancha);

            if (tipoCancha == null)
            {
                throw new ExceptionNotFound("El tipo de cancha no fue encontrado");
            }
            if(request.Horarios == null || !request.Horarios.Any()) 
            {
                throw new ExceptionBadRequest("Tiene que ingresar un horario");
            }

            foreach (var horario in request.Horarios) 
            {
                if (horario.HoraInicio > horario.HoraFin) 
                {
                    throw new ExceptionBadRequest("El horario de inicio debe ser mayor al horario de fin");
                }
            }

            var cancha = new Cancha
            {
                TipoCanchaId = request.IdTipoCancha,
                Nombre = request.Nombre,
                Estado = true,
                Disponibilidad = new List<HorarioCancha>()
            };

            var canchaCreada = await _canchaCommand.CrearCancha(cancha);
            var slotsTotales = new List<HorarioCancha>();
            foreach (var h in request.Horarios)
            {
                var slots = GenerarSlots(h.Dia, h.HoraInicio, h.HoraFin, tipoCancha.Duracion, canchaCreada.IdCancha);

                slotsTotales.AddRange(slots);
            }
            canchaCreada.Disponibilidad = slotsTotales;
            await _canchaCommand.ModificarCancha(canchaCreada);

            return new CanchaResponse
            {
                IdCancha = canchaCreada.IdCancha,
                Nombre = canchaCreada.Nombre,

                tipoCancha = new DTOs.Response.TipoCancha.TipoCanchaResponse
                {
                    Id = canchaCreada.TipoCancha.IdTipoCancha,
                    Nombre = canchaCreada.TipoCancha.Nombre,
                    Superficie = canchaCreada.TipoCancha.Superficie,
                    Capacidad = canchaCreada.TipoCancha.Capacidad,
                    Precio = canchaCreada.TipoCancha.Precio,
                    Duracion = canchaCreada.TipoCancha.Duracion,
                },

                Disponibilidad = canchaCreada.Disponibilidad.Select(horario => new HorarioCanchaResponse 
                {
                    HorarioCanchaId=horario.Id,
                    Dia=horario.Dia,
                    HoraInicio=horario.HoraInicio, 
                    HoraFin=horario.HoraFin,
                   
                }).ToList()
            };
        }

        public async Task<CanchaResponse> ConsultarCancha(int canchaId)
        {
            if (canchaId <= 0)
            {
                throw new ExceptionBadRequest("Ingrese un número válido");
            }

            var cancha = await _canchaQuery.ConsultarCancha(canchaId);

            if (cancha == null)
            {
                throw new ExceptionNotFound("Cancha no encontrada");
            }

            return new CanchaResponse
            {
                IdCancha = cancha.IdCancha,

                tipoCancha = new DTOs.Response.TipoCancha.TipoCanchaResponse
                {
                    Id = cancha.TipoCancha.IdTipoCancha,
                    Nombre = cancha.TipoCancha.Nombre,
                    Superficie = cancha.TipoCancha.Superficie,
                    Capacidad = cancha.TipoCancha.Capacidad,
                    Precio = cancha.TipoCancha.Precio,
                    Duracion = cancha.TipoCancha.Duracion,
                },

                Disponibilidad = cancha.Disponibilidad.Select(horario => new HorarioCanchaResponse
                {HorarioCanchaId = horario.Id,
                    Dia = horario.Dia,
                    HoraInicio = horario.HoraInicio,
                    HoraFin = horario.HoraFin,
                    
                }).ToList()
            };
        }

        public async Task<CanchaResponse> ModificarHorarioCancha(ActualizarHorarioCanchaRequest request)
        {
            if (request.CanchaId <= 0)
            {
                throw new ExceptionBadRequest("Ingrese un valor válido");
            }
            if (request.HoraInicio >= request.HoraFin)
            {
                throw new ExceptionBadRequest("Hora inicio debe ser menor a hora fin");

            }

            var cancha = await _canchaQuery.ConsultarCancha(request.CanchaId);

            if (cancha == null)
            {
                throw new ExceptionNotFound("Cancha no encontrada");
            }
            cancha.Disponibilidad.RemoveAll(horario => horario.Dia == request.Dia);

            var nuevosSlots = GenerarSlots(request.Dia,request.HoraInicio,request.HoraFin,cancha.TipoCancha.Duracion,cancha.IdCancha);

            var canchaAct = await _canchaCommand.ModificarCancha(cancha);

            return new CanchaResponse
            {
                IdCancha = canchaAct.IdCancha,

                tipoCancha = new DTOs.Response.TipoCancha.TipoCanchaResponse
                {
                    Id = canchaAct.TipoCancha.IdTipoCancha,
                    Nombre = canchaAct.TipoCancha.Nombre,
                    Superficie = canchaAct.TipoCancha.Superficie,
                    Capacidad = canchaAct.TipoCancha.Capacidad,
                    Precio = canchaAct.TipoCancha.Precio,
                    Duracion = canchaAct.TipoCancha.Duracion,
                },

                Disponibilidad = cancha.Disponibilidad.Select(horario => new HorarioCanchaResponse
                {
                    HorarioCanchaId = horario.Id,
                    Dia = horario.Dia,
                    HoraInicio = horario.HoraInicio,
                    HoraFin = horario.HoraFin,
                    
                }).ToList(),
            };
        }

        public async Task<CanchaResponse> EliminarCancha(int canchaId)
        {
            if (canchaId <= 0)
            {
                throw new ExceptionBadRequest("Ingrese un valor válido");
            }

            var cancha = await _canchaQuery.ConsultarCancha(canchaId);

            if (cancha == null)
            {
                throw new ExceptionNotFound("Cancha no encontrada");
            }

            await _canchaCommand.EliminarCancha(cancha);

            return new CanchaResponse
            {
                IdCancha = cancha.IdCancha,

                tipoCancha = new DTOs.Response.TipoCancha.TipoCanchaResponse
                {
                    Id = cancha.TipoCancha.IdTipoCancha,
                    Nombre = cancha.TipoCancha.Nombre,
                    Superficie = cancha.TipoCancha.Superficie,
                    Capacidad = cancha.TipoCancha.Capacidad,
                    Precio = cancha.TipoCancha.Precio,
                    Duracion = cancha.TipoCancha.Duracion,
                },

                Disponibilidad = cancha.Disponibilidad.Select(horario => new HorarioCanchaResponse
                {HorarioCanchaId = horario.Id,
                    Dia = horario.Dia,
                    HoraInicio = horario.HoraInicio,
                    HoraFin = horario.HoraFin,
                   
                }).ToList(),
            };
        }

        public async Task<List<CanchaResponse>> ListarCanchas()
        {
            var canchas = await _canchaQuery.ListarCanchas();

            return canchas.Select(cancha => new CanchaResponse
            {
                IdCancha = cancha.IdCancha,
                Nombre=cancha.Nombre,

                tipoCancha = new DTOs.Response.TipoCancha.TipoCanchaResponse
                {
                    Id = cancha.TipoCancha.IdTipoCancha,
                    Nombre = cancha.TipoCancha.Nombre,
                    Superficie = cancha.TipoCancha.Superficie,
                    Capacidad = cancha.TipoCancha.Capacidad,
                    Precio = cancha.TipoCancha.Precio,
                    Duracion = cancha.TipoCancha.Duracion,
                },

                Disponibilidad = cancha.Disponibilidad.Select(horario => new HorarioCanchaResponse
                {HorarioCanchaId = horario.Id,
                    Dia = horario.Dia,
                    HoraInicio = horario.HoraInicio,
                    HoraFin = horario.HoraFin,
                }).ToList(),

            }).ToList();
        }

        public async Task<CanchaResponse> CambiarEstado(int canchaId)
        {
            if (canchaId <= 0)
            {
                throw new ExceptionBadRequest("Ingrese un valor válido");
            }

            var cancha = await _canchaQuery.ConsultarCancha(canchaId);

            if (cancha == null)
            {
                throw new ExceptionNotFound("Cancha no encontrada");
            }

            cancha.Estado = false;

            await _canchaCommand.CambiarEstado(cancha);

            return new CanchaResponse
            {
                IdCancha = cancha.IdCancha,

                tipoCancha = new DTOs.Response.TipoCancha.TipoCanchaResponse
                {
                    Id = cancha.TipoCancha.IdTipoCancha,
                    Nombre = cancha.TipoCancha.Nombre,
                    Superficie = cancha.TipoCancha.Superficie,
                    Capacidad = cancha.TipoCancha.Capacidad,
                    Precio = cancha.TipoCancha.Precio,
                    Duracion = cancha.TipoCancha.Duracion,
                },

                Disponibilidad = cancha.Disponibilidad.Select(horario => new HorarioCanchaResponse
                {
                    HorarioCanchaId = horario.Id,
                    Dia = horario.Dia,
                    HoraInicio = horario.HoraInicio,
                    HoraFin = horario.HoraFin,
                }).ToList(),
            };
        }

        public async Task<List<HorarioCanchaResponse>> VerDisponibilidad(int CanchaId, DateOnly fecha)
        {
            if (CanchaId <= 0)
            {
                throw new ExceptionBadRequest("Ingrese una cancha valida");
            }

            var cancha = await _canchaQuery.ConsultarCancha(CanchaId);
            if (cancha == null)
            {
                throw new ExceptionNotFound("La cancha ingresada no fue encontrada");
            }

            var diaSeleccionado = fecha.DayOfWeek;

            var horarios = await _canchaQuery.VerDisponibilidad(cancha.IdCancha);

            var horariosDelDia = horarios
                .Where(h => h.Dia == diaSeleccionado)
                .ToList();

            var reservas = await _reservaQuery.ListarPorCanchaYFecha(cancha.IdCancha, fecha);

            var ocupados = reservas.Select(r => r.IdCanchaHorario).ToHashSet();

            var resultado = horariosDelDia.Select(h => new HorarioCanchaResponse
            {
                HorarioCanchaId=h.Id,
                Dia = h.Dia,
                HoraInicio = h.HoraInicio,
                HoraFin = h.HoraFin,
                Disponible = !ocupados.Contains(h.Id)
            }).ToList();

            return resultado;
        }


        private List<HorarioCancha> GenerarSlots(DayOfWeek dia,TimeSpan inicio,TimeSpan fin,int duracionHoras,int canchaId)
        {
            var slots = new List<HorarioCancha>();

            var duracion = TimeSpan.FromHours(duracionHoras);
            var actual = inicio;

            while (actual + duracion <= fin)
            {
                slots.Add(new HorarioCancha
                {
                    IdCancha = canchaId,
                    Dia = dia,
                    HoraInicio = actual,
                    HoraFin = actual + duracion,
                });

                actual = actual + duracion;
            }

            return slots;
        }

        
    }
}