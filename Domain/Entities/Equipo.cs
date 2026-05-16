
namespace Domain.Entities
{
    public class Equipo
    {
        public int IdEquipo { get; set; }
        public string Nombre { get; set; }
        public int Victorias { get; set; }
        public int Derrotas { get; set; }
        public IEnumerable<Partido>Partidos { get; set; }
        public bool Estado { get; set; }
    }
}
