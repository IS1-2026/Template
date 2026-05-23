
using Application.DTOs.Response.HorarioCancha;

namespace Application.DTOs.Response.Reserva
{
    public class ReservaResponse
    {
        public int ReservaId { get; set; }
        public int DniCliente { get;set; }
        public ReservaHorarioCanchaResponse ReservaHorarioCanchaResponse { get; set; }
        public double Total { get; set; }
        public string NombreCancha { get; set; }
        public bool esValida { get; set; }
    }
}
