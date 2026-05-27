using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Request.Competencias;
using Application.DTOs.Response.Competencias;
using Application.DTOs.Response.Equipos;
using Application.DTOs.Response.Partidos;
using Application.Exceptions;
using Application.Interfaces.Competencias;
using Domain.Entities;

namespace Application.UseCases
{
    public class CompetenciaService : ICompetenciaService
    {
        private readonly ICompetenciaCommand _competenciaCommand;
        private readonly ICompetenciaQuery _competenciaQuery;
        public CompetenciaService(ICompetenciaCommand competenciaCommand, ICompetenciaQuery competenciaQuery)
        {
            _competenciaCommand = competenciaCommand;
            _competenciaQuery = competenciaQuery;
        }

        public async Task<int> CrearCompetencia(CrearCompetenciaRequest request)
        {
            Competencia competencia = request.tipo switch
            {
                "Liga" => new Liga(),
                "Torneo" => new Torneo(),
                _ => throw new ExceptionBadRequest("Formato invalido")
            };

            competencia.Nombre = request.nombre;
            competencia.Descripcion = request.descripcion;
            competencia.Cupos = request.cupos;
            competencia.Precio = request.precio;

            return await _competenciaCommand.CrearCompetencia(competencia);

        }

        public async Task ModificarCompetencia(ModificarCompetenciaRequest request)
        {
            var competencia = await _competenciaQuery.ObtenerCompetenciaPorId(request.id)
                ?? throw new KeyNotFoundException($"No se encontro competencias con id: {request.id}");

            competencia.Nombre = request.nombre ?? competencia.Nombre;
            competencia.Descripcion = request.descripcion ?? competencia.Descripcion;
            competencia.Cupos = request.cupos != 0 ? request.cupos : competencia.Cupos;
            competencia.Precio = request.precio != 0 ? request.precio : competencia.Precio;

            await _competenciaCommand.ModificarCompetencia(competencia);
        }

        public async Task<CompetenciaResponse?> ObtenerCompetenciaPorId(int id)
        {
            var competencia = await _competenciaQuery.ObtenerCompetenciaPorId(id);
            if (competencia is null) return null;

            return new CompetenciaResponse
            {
                CompetenciaId= competencia.IdCompetencia,
                Nombre = competencia.Nombre,
                Cupos = competencia.Cupos,
                Descripcion = competencia.Descripcion,
                Precio = competencia.Precio,
                Tipo=competencia.GetType().Name
            };
        }

        public async Task EliminarCompetencia(int idCompetencia)
        {
            var competencia = await _competenciaQuery.ObtenerCompetenciaPorId(idCompetencia)
                ?? throw new KeyNotFoundException($"No se encontro competencias con id: {idCompetencia}");

            await _competenciaCommand.EliminarCompetencia(competencia);
        }

        public async Task<int> AgregarEquipo(AgregarEquipoRequest request,int idCompetencia)
        {
            var competencia = await _competenciaQuery.ObtenerCompetenciaPorId(idCompetencia)
                 ?? throw new KeyNotFoundException($"No se encontro competencias con id: {idCompetencia}");

            if (competencia.Equipos.Count() >= competencia.Cupos)
            {
                throw new InvalidOperationException($"Cupo maximo alcanzado en la competencia {competencia.Nombre}");
            }

            if (competencia.Equipos.Any(e => e.Nombre == request.nombre))
            {
                throw new InvalidOperationException($"Ya existe un equipo con el nombre {request.nombre}");
            }

            var equipo = new Equipo
            {
                Nombre = request.nombre
            };

            await _competenciaCommand.AgregarEquipo(equipo, idCompetencia);
            return equipo.IdEquipo;
        }

        public async Task<IEnumerable<CompetenciaResponse?>> ObtenerTodasLasCompetencias()
        {
            var lista = await _competenciaQuery.ObtenerTodasLasCompetencias();
            if (lista is null) return null;

            return lista.Select(c => new CompetenciaResponse
            {
                CompetenciaId=c.IdCompetencia,
                Nombre = c.Nombre,
                Cupos = c.Cupos,
                Descripcion = c.Descripcion,
                Precio = c.Precio,
                Tipo=c.GetType().Name,
            });
        }

        public async Task<IEnumerable<EquipoResponse?>> ObtenerEquipos(int idcompetencia)
        {
            var equipos = await _competenciaQuery.ObtenerEquipos(idcompetencia);
            return equipos.Select(e => new EquipoResponse
            {
                id = e.IdEquipo,
                nombre = e.Nombre,
                derrotas = e.Derrotas,
                victorias = e.Victorias

            });
        }
        public async Task<IEnumerable<PartidoResponseCompetencia?>> ObtenerPartidos(int idcompetencia)
        {
            var partidos = await _competenciaQuery.ObtenerPartidos(idcompetencia);
            return partidos.Select(p => new PartidoResponseCompetencia
            {
                resultado = p.Resultado,
                horaInicio = p.HoraInicio,
                horaFin = p.HoraFin,
                EquipoLocal = p.EquipoLocal.Nombre,
                EquipoVis = p.EquipoVis.Nombre
            });
        }
        public async Task<bool> CompetenciaExiste(int idcompetencia)
        {
            return await _competenciaQuery.CompetenciaExiste(idcompetencia);
        }
    }
}



