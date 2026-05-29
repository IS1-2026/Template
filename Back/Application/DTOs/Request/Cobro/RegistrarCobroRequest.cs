

namespace Application.DTOs.Request.Cobro
{
    public class RegistrarCobroRequest
    {
        public int? IdReserva { get; set; }
        public int? IdInscripcion { get; set; }
        public decimal MontoTotal { get; set; }
        public string MetodoPago { get; set; } 
        public int DniCliente { get; set; }
        public string Motivo { get; set; }
    }
}
