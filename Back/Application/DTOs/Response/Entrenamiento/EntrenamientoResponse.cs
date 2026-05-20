using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response.Entrenamiento
{
     public class EntrenamientoResponse
    {
        public int Id_Entrenamiento { get; set; }
        public int Dni_Entrenador { get; set; }
        public double Precio  { get; set; }

    }
}
