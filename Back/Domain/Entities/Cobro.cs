

namespace Domain.Entities
{
    public class Cobro
    {
        public int IdCobro { get; set; }
        //FK
        public int? IdReserva { get; set; }
        public int? IdInscripcion { get; set; }
        public int DniCliente { get; set; }
        public string MetodoPago { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Motivo { get; set; }
        public bool EstaCompleto { get; set; }
        public double MontoTotal { get; set; }
       

        //Relación
        public Reserva? Reserva { get; set; }
        public Inscripcion? Inscripcion { get; set; }
        public Cliente Cliente { get; set; }

    }
}
