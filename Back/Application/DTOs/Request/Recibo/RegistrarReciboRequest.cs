using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Recibo
{
    public class RegistrarReciboRequest
    {
        public int IdCobro { get; set; }
        public int IdReserva { get; set; }
        public double MontoTotal { get; set; }
        public DateTime FechaEmision { get; set; }
    }
}
