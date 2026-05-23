
namespace Domain.Entities
{
    public class Clase
    {
        public int IdClase { get; set; }
        public int Cupo { get; set; }
        public IEnumerable<Inscripcion> Inscripto { get; set; }
        public int DniProfesor {  get; set; }
        public double Precio { get; set; }

        public int IdActividad { get; set; }

        //Relación
        public Profesor Profesor { get; set; }

        
    }
}
