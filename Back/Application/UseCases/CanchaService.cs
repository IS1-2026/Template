using Application.DTOs.Request.Cancha;
using Application.DTOs.Response.Cancha;
using Application.Exceptions;
using Application.Interfaces.Cancha;
using Application.Interfaces.TipoCancha;

namespace Application.UseCases
{
    public class CanchaService : ICanchaService
    {
        private readonly ICanchaCommand _canchaCommand;
        private readonly ICanchaQuery _canchaQuery;
        private readonly ITipoCanchaQuery _tipoCanchaQuery;

        public CanchaService(ICanchaCommand canchaCommand,ICanchaQuery canchaQuery,ITipoCanchaQuery tipoCanchaQuery)
        {
            _canchaCommand = canchaCommand;
            _canchaQuery = canchaQuery;
            _tipoCanchaQuery = tipoCanchaQuery;
        }

        public async Task<CanchaResponse> CrearCancha(CrearCanchaRequest request)
        {
            if (request.IdTipoCancha <= 0)
            {
                throw new ExceptionBadRequest("Ingrese un id válido");
            }

            var horaInicio = TimeSpan.Parse(request.HoraInicio);
            var horaFin = TimeSpan.Parse(request.HoraFin);

            if (horaInicio >= horaFin)
            {
                throw new ExceptionBadRequest("La hora de inicio debe ser menor a la hora fin");
            }

            var tipoCancha = await _tipoCanchaQuery.ObtenerTipoCancha(request.IdTipoCancha);

            if (tipoCancha == null)
            {
                throw new ExceptionNotFound("El tipo de cancha no fue encontrado");
            }

            var disponibilidad = GenerarDisponibilidad(horaInicio,horaFin,tipoCancha.Duracion);

            var cancha = new Domain.Entities.Cancha
            {
                TipoCanchaId = request.IdTipoCancha,
                Disponibilidad = disponibilidad,
                Estado = true,
                TipoCancha = tipoCancha
            };

            var canchaCreada = await _canchaCommand.CrearCancha(cancha);

            return new CanchaResponse
            {
                IdCancha = canchaCreada.IdCancha,

                tipoCancha = new DTOs.Response.TipoCancha.TipoCanchaResponse
                {
                    Id = canchaCreada.TipoCancha.IdTipoCancha,
                    Nombre = canchaCreada.TipoCancha.Nombre,
                    Superficie = canchaCreada.TipoCancha.Superficie,
                    Capacidad = canchaCreada.TipoCancha.Capacidad,
                    Precio = canchaCreada.TipoCancha.Precio,
                    Duracion = canchaCreada.TipoCancha.Duracion,
                },

                Disponibilidad = canchaCreada.Disponibilidad,
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

                Disponibilidad = cancha.Disponibilidad,
            };
        }

        public async Task<CanchaResponse> ModificarCancha(ActualizarCanchaRequest request)
        {
            if (request.CanchaId <= 0)
            {
                throw new ExceptionBadRequest("Ingrese un valor válido");
            }

            var horaInicio = TimeSpan.Parse(request.HoraInicio);
            var horaFin = TimeSpan.Parse(request.HoraFin);

            if (horaInicio >= horaFin)
            {
                throw new ExceptionBadRequest("La hora de inicio debe ser menor a la hora fin");
            }

            var cancha = await _canchaQuery.ConsultarCancha(request.CanchaId);

            if (cancha == null)
            {
                throw new ExceptionNotFound("Cancha no encontrada");
            }

            cancha.Disponibilidad = GenerarDisponibilidad(horaInicio,horaFin,cancha.TipoCancha.Duracion);

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

                Disponibilidad = canchaAct.Disponibilidad,
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

                Disponibilidad = cancha.Disponibilidad,
            };
        }

        public async Task<List<CanchaResponse>> ListarCanchas()
        {
            var canchas = await _canchaQuery.ListarCanchas();

            return canchas.Select(cancha => new CanchaResponse
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

                Disponibilidad = cancha.Disponibilidad,

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

                Disponibilidad = cancha.Disponibilidad,
            };
        }

        private List<TimeSpan> GenerarDisponibilidad(TimeSpan horaInicio,TimeSpan horaFin,int horas){
            var disponibilidad = new List<TimeSpan>();

            var horaActual = horaInicio;

            while (horaActual.Add(TimeSpan.FromHours(horas)) <= horaFin)
            {
                disponibilidad.Add(horaActual);

                horaActual = horaActual.Add(
                    TimeSpan.FromHours(horas));
            }

            return disponibilidad;
        }
    }
}