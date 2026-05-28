
namespace Application.DTOs.Request.Clase
{
    public class ProgramarClasesRequest
    {
        public string Nombre { get; set; }
        public int Cupo { get; set; }
        public DateOnly Dia { get; set; }
        public TimeSpan Hora { get; set; }
        public int DniProfesor { get; set; }
        public double Precio { get; set; }
        
    }
}
