
namespace Domain.Entities
{
    public class Competencia
    {
        public int IdCompetencia { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cupos { get; set; }
        public ICollection<Inscripcion> Inscriptos { get; set; } = new List<Inscripcion>();
        public ICollection<Equipo>Equipos { get; set; } = new List<Equipo>();
        public double Precio { get; set; }

        public ICollection<Partido> Partidos { get; set; } = new List<Partido>();
    }
}
