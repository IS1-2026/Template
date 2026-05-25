using Application.DTOs.Response.Entrenamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response.Profesional
{
    public class EntrenadorResponse : ProfesionalResponse
    {

        public List<EntrenamientoResponse> Entrenamientos { get; set; } = new List<EntrenamientoResponse>();

    }
}
