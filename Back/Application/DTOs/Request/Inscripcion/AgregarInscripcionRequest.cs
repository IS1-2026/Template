using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Inscripcion
{
    public class AgregarInscripcionRequest
    {
        public int IdInscripcion { get; set; }
        public int DniCliente { get; set; }
        public DateTime Horario { get; set; }
        public double PrecioInscr { get; set; }
        public int NroAct { get; set; } //1- Entrenamiento,2- Clase, 3- Competición, etc


        public int IdAct { get; set; }
        public int IdCancha { get; set; }
        public int IdDescuento { get; set; }
    }
}
