

namespace Domain.Entities
{
    public class Reserva
    {
        public int IdReserva {  get; set; }
        //FKs
        public int DniCliente { get; set; }
        public int IdCancha { get; set; }
        public int? IdDescuento { get; set; }
        public DateTime FechaRes {  get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFin { get; set; }
        public double MontoTotal { get; set; }
        public bool EsValida { get; set; }
         
        

        //Relaciones

        public Cliente Cliente { get; set; }
        public Cancha Cancha { get; set; }

    }
}
