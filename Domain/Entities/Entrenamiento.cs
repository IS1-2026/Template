
namespace Domain.Entities
{
    public class Entrenamiento
    {
        public int IdEntrenamiento { get; set; }
        public IEnumerable<Inscripcion>Inscriptos { get; set; }
        public int DniEntrenador { get; set; }
        public double Precio { get; set; }

        //Relación
        public Entrenador Entrenador { get; set; }
    }
}
