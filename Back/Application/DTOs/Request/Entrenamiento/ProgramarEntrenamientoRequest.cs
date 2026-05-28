using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Entrenamiento
{
     public class ProgramarEntrenamientoRequest
    {
        public string Nombre { get; set; }
        public int Dni_Entrenador {  get; set; }
        public DateOnly Fecha { get; set; }
        public TimeSpan Horario { get; set; }
        public int Cupo {  get; set; }
        public double Precio { get; set; } 

    }
}
