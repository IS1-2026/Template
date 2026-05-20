using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Entrenamiento
{
    public class ModificarEntrenamientoRequest
    {
        public int Id_Entrenamiento { get; set; }
        public int Dni_Entrenador { get; set; }
        public double Precio { get; set; }
    }
}
