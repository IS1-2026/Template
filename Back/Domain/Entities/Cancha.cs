
namespace Domain.Entities
{
    public class Cancha
    {
        public int IdCancha { get; set; }
        //FKs
        public int TipoCanchaId { get; set; }
        public List<TimeSpan> Disponibilidad { get; set; }

        public bool Estado { get; set; }

        //Relación 
        public TipoCancha TipoCancha { get; set; }

    }
}
