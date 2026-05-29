using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Partidos
{
    public class ModificarPartidoRequest
    {
        public int idPartido { get; set; }
        public int idCompetencia { get; set; }
        public int idEquipoLocal { get; set; }
        public int idEquipoVis { get; set; }
        public int? GolesLocal { get; set; }
        public int? GolesVis { get; set; }
        public DateTime horarioinicio { get; set; }
        public DateTime horariofin { get; set; }
    }
}