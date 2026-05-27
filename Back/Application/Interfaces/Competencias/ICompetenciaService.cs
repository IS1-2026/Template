using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.DTOs.Request.Competencias;
using Application.DTOs.Response.Competencias;
using Application.DTOs.Response.Equipos;
using Application.DTOs.Response.Partidos;

namespace Application.Interfaces.Competencias
{
    public interface ICompetenciaService
    {
        Task<int> CrearCompetencia(CrearCompetenciaRequest competencia);
        Task ModificarCompetencia(ModificarCompetenciaRequest competencia);
        Task<int> AgregarEquipo(AgregarEquipoRequest request,int idCompetencia);
        Task EliminarCompetencia(int idCompetencia);
        Task<CompetenciaResponse?> ObtenerCompetenciaPorId(int id);
        Task<IEnumerable<CompetenciaResponse?>> ObtenerTodasLasCompetencias();
        Task<IEnumerable<EquipoResponse?>> ObtenerEquipos(int idcompetencia);
        Task<IEnumerable<PartidoResponseCompetencia?>> ObtenerPartidos(int id);
        Task<bool> CompetenciaExiste(int idcompetencia);

    }

}
