namespace Application.DTOs.Request.Reserva
{
    public class CrearReservaRequest
    {
        public int DniCliente { get; set; }
        public int IdCancha { get; set; }
        public int IdCanchaHorario { get; set; }
        public DateOnly Fecha { get; set; }
    }
}
