using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Profesional
{
    public class RegistrarEntrenadorRequest 
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Localidad { get; set; }
        public string Pais { get; set; }
        public DateOnly FechaNac { get; set; }
        public string Certificado { get; set; }
    }
}
