

namespace Domain.Entities
{
    public class Reserva
    {
        public int IdReserva {  get; set; }
        //FKs
        public int DniCliente { get; set; }
        public int IdCancha { get; set; }
        public int IdCanchaHorario { get; set; }
        public DateOnly Fecha { get; set; } 
        public int? IdDescuento { get; set; }
                
        public double MontoTotal { get; set; }
        public bool EsValida { get; set; }
         
        

        //Relaciones

        public Cliente Cliente { get; set; }
        public Cancha Cancha { get; set; }
        public HorarioCancha HorarioCancha { get; set; }
        public Cobro Cobro { get; set; }

    }
}
