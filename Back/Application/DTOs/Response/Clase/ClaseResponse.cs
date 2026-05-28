

namespace Application.DTOs.Response.Clase
{
    public  class ClaseResponse
    {
        public string Nombre { get; set; }
        public int IdClase { get; set; }
        public int Cupo { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int DniProfesor { get; set; }
        public double Precio { get; set; }
  
    }
}
