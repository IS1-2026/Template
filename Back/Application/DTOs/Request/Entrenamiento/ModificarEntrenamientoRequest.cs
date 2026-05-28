

namespace Application.DTOs.Request.Entrenamiento
{
    public class ModificarEntrenamientoRequest
    {
        public string? Nombre { get; set; }
        public int? Dni_Entrenador { get; set; }
        public DateOnly? Fecha { get; set; }
        public TimeSpan? Horario { get; set; } 
        public double? Precio { get; set; }
    }
}
