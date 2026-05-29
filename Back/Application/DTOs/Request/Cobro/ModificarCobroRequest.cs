using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Cobro
{
    public class ModificarCobroRequest
    {
        public int Id_Cobro { get; set; }
        public bool EstaCompleto { get; set; }
        public decimal MontoTotal { get; set; }
    }
}
