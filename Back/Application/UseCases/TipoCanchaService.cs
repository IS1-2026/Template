using Application.DTOs.Request.Cancha;
using Application.DTOs.Request.TipoCancha;
using Application.DTOs.Response.TipoCancha;
using Application.Exceptions;
using Application.Interfaces.TipoCancha;
using Domain.Entities;
using System.Data;

namespace Application.UseCases
{
    public class TipoCanchaService : ITipoCanchaService
    {
        private readonly ITipoCanchaCommand _command;
        private readonly ITipoCanchaQuery _query;

        public TipoCanchaService(ITipoCanchaCommand command, ITipoCanchaQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<TipoCanchaResponse> CrearTipoCancha(CrearTipoCanchaRequest request)
        {
            if (string.IsNullOrEmpty(request.Nombre))
            {
                throw new ExceptionBadRequest("Debe ingresar un nombre valido");
            }

            if (String.IsNullOrEmpty(request.Superficie))
            {
                throw new ExceptionBadRequest("Debe ingresar una superficie valida");
            }

            if (request.Capacidad <= 0)
            {
                throw new ExceptionBadRequest("Debe ingresar una capacidad valida");
            }

            if (request.Duracion <= 0)
            {
                throw new ExceptionBadRequest("Debe ingresar una duracion valida");
            }

            if (request.Precio <= 0)
            {
                throw new ExceptionBadRequest("Debe ingresar un precio valido");
            }

            var tipoCancha = new TipoCancha
            { 
                Nombre = request.Nombre,
                Superficie = request.Superficie,
                Capacidad = request.Capacidad,
                Duracion = request.Duracion,
                Precio = request.Precio,
            };

            var tipoCanchaCreada = await _command.CrearTipoCancha(tipoCancha);

            return new TipoCanchaResponse
            {
                Id=tipoCanchaCreada.IdTipoCancha,
                Nombre = tipoCanchaCreada.Nombre,
                Superficie = tipoCanchaCreada.Superficie,
                Capacidad = tipoCanchaCreada.Capacidad,
                Precio = tipoCanchaCreada.Precio,
                Duracion = tipoCanchaCreada.Duracion,
            };
        }

        public async Task<TipoCanchaResponse> EditarTipoCancha(int tipoCanchaId,ActualizarTipoCanchaRequest request)
        {
            var tipoCancha = await _query.ObtenerTipoCancha(tipoCanchaId) ?? throw new ExceptionNotFound("Tipo cancha no encontrado");

            if (request.Capacidad <= 0)
            {
                throw new ExceptionBadRequest("Ingrese una capacidad valido");
            }
            if (request.Precio <= 0)
            {
                throw new ExceptionBadRequest("Ingrese un precio valido");
            }
            if (request.Duracion <= 0)
            {
                throw new ExceptionBadRequest("Ingrese una duración valido");
            }

            tipoCancha.Nombre = request.Nombre ?? tipoCancha.Nombre;
            tipoCancha.Duracion = request.Duracion ?? tipoCancha.Duracion;
            tipoCancha.Capacidad = request.Capacidad ?? tipoCancha.Capacidad;
            tipoCancha.Superficie = request.Superficie ?? tipoCancha.Superficie;
            tipoCancha.Precio = request.Precio ?? tipoCancha.Precio;
            var tipoCanchaAct = await _command.ActualizarTipoCancha(tipoCancha);

            return new TipoCanchaResponse
            {
                Id = tipoCanchaAct.IdTipoCancha,
                Nombre = tipoCanchaAct.Nombre,
                Superficie = tipoCanchaAct.Superficie,
                Capacidad = tipoCanchaAct.Capacidad,
                Precio = tipoCanchaAct.Precio,
                Duracion = tipoCanchaAct.Duracion,
            };
        }

        public async Task<List<TipoCanchaResponse>> ListarTipoCancha()
        {
            var canchas = await _query.ListarTipoCanchas();

            return canchas.Select(tipoCancha =>  new TipoCanchaResponse
            {
                Id = tipoCancha.IdTipoCancha,
                Nombre = tipoCancha.Nombre,
                Superficie = tipoCancha.Superficie,
                Capacidad = tipoCancha.Capacidad,
                Precio = tipoCancha.Precio,
                Duracion = tipoCancha.Duracion,
            }).ToList(); 

        }
    }
}
