using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Application.DTOs.Response.Competencias;

public class PartidoResponseCompetencia
{
    public int? GolesLocal { get; set; }
    public int? GolesVis { get; set; }
    public DateTime horaInicio { get; set; }
    public DateTime horaFin { get; set; }
    public string EquipoLocal { get; set; }
    public string EquipoVis { get; set; }
}
