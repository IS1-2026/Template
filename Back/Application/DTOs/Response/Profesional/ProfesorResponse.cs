using Application.DTOs.Response.Clase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response.Profesional
{
    public class ProfesorResponse : ProfesionalResponse
    {
        public List<ClaseResponse> Clases { get; set; } = new List<ClaseResponse>();
    }
}
