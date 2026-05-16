
namespace Domain.Entities
{
    public class Clase
    {
        public int IdClase { get; set; }
        public int Cupo { get; set; }
        public IEnumerable<Inscripcion> Inscripto { get; set; }
        public int IdProfesor {  get; set; }
        public double Precio { get; set; }

        //Relación
        public Profesor Profesor { get; set; }

        
    }
}
