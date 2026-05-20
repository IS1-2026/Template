
namespace Application.DTOs.Response.Reserva
{
    public class ReservaResponse
    {
        public int ReservaId { get; set; }
        public int DniCliente{ get;set; }
        public int? IdDescuento { get; set; }
        public DateTime FechaRes {  get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin {  get; set; }
        public double Total { get; set; }
    }
}
