using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Clase
{
    public class ModificarClaseRequest
    {
        public int IdClase { get; set; }
        public int Cupo { get; set; }
        public int DniProfesor { get; set; }
        public double Precio { get; set; }
    }
}
