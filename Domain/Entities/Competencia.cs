
namespace Domain.Entities
{
    public class Competencia
    {
        public int IdCompeticion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cupos { get; set; }
        public IEnumerable<Inscripcion> Inscriptos { get; set; }
        public IEnumerable<Equipo>Equipos { get; set; }
        public double Precio { get; set; }
    }
}
