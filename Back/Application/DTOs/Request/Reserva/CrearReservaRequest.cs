namespace Application.DTOs.Request.Reserva
{
    public class CrearReservaRequest
    {
        public int DniCliente { get; set; }
        public int IdCancha { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFin { get; set; }
    }
}
