
namespace Domain.Entities
{
    public class Cancha
    {
        public int IdCancha { get; set; }
        public string Nombre { get; set; }
        //FKs
        public int TipoCanchaId { get; set; }
        public List<HorarioCancha> Disponibilidad { get; set; }

        public bool Estado { get; set; }

        //Relación 
        public TipoCancha TipoCancha { get; set; }

    }
}
