
namespace Domain.Entities
{
    public class Recibo
    {
        public int IdRecibo { get; set; }
        public int IdCobro { get; set; }
        public int IdReserva { get; set; }
        public double MontoTotal { get; set; }
        public DateTime FechaEmision { get; set; }

        //Relación

        public Cobro Cobro { get; set; }
        public Reserva Reserva { get; set; }

    }
}
