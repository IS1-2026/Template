

namespace Domain.Entities
{
    public class Cobro
    {
        public int IdCobro { get; set; }
        //FK
        public int IdReserva { get; set; }
        public bool EstaCompleto { get; set; }
        public double MontoTotal { get; set; }

        //Relación
        public Reserva Reserva { get; set; }

    }
}
