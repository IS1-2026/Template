using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response.Recibo
{
    public class ReciboResponse
    {
        public int Id_Recibo { get; set; }
        public int Id_Cobro { get; set; }
        public int Id_Reserva { get; set; }
        public double MontoTotal { get; set; }
        public DateTime FechaEmision { get; set; }
    }
}
