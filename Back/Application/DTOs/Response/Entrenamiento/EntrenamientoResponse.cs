

namespace Application.DTOs.Response.Entrenamiento
{
     public class EntrenamientoResponse
    {
        public string Nombre { get; set; }
        public int Id_Entrenamiento { get; set; }
        public int Dni_Entrenador { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeSpan Horario { get; set; }
        public int Cupo { get; set; }
        public double Precio  { get; set; }

    }
}
