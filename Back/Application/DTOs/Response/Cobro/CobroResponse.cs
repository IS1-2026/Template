using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response.Cobro
{
    public class CobroResponse
    {
        public int Id_Cobro { get; set; }
        public int? Id_Reserva { get; set; }
        public int? IdInscripcion { get; set; }
        public int clienteDni { get; set; }
        public string metodoPago { get; set; }
        public bool EstaCompleto { get; set; }
        public decimal MontoTotal { get; set; }
    }
}
