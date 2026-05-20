
namespace Domain.Entities
{
    public class Profesor:Profesional
    {
        public IEnumerable<Clase> Clases { get; set; }
    }
}
