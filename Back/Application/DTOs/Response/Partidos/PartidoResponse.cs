using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Application.DTOs.Response.Partidos
{
    public class PartidoResponse
    {
            public int IdPartido { get; set; }
            public int IdCompetencia { get; set; }
            public int? IdEquipoLocal { get; set; }
            public int? IdEquipoVis { get; set; }
            public int? GolesLocal { get; set; }
            public int? GolesVis { get; set; }
            public DateTime HoraInicio { get; set; }
            public DateTime HoraFin { get; set; }
            public string Estado { get; set; } 
    }
}
