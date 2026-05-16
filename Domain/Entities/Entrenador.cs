
namespace Domain.Entities
{
    public class Entrenador:Profesional 
    {
        IEnumerable<Entrenamiento> Entrenamientos { get; set; }
    }
}
