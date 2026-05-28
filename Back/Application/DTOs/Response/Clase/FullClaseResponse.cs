
using Application.DTOs.Response.Profesional;

namespace Application.DTOs.Response.Clase
{
    public class FullClaseResponse
    {
        public string Nombre { get; set; }
        public int IdClase { get; set; }
        public int Cupo { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public ProfesionalResponse Profesional{ get; set; }
        public double Precio { get; set; }
        public int NroActividad { get; set; }
    }
}
