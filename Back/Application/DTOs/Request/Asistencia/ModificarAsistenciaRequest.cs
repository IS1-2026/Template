using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Asistencia
{
    public class ModificarAsistenciaRequest
    {
        public int IdAsistencia { get; set; }
        public int DniCliente { get; set; }
        public int IdClase { get; set; }
        public bool Presente { get; set; }
    }
}
