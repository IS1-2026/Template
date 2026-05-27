

namespace Application.DTOs.Response.Competencias
{

    public class CompetenciaResponse
    {
        public int CompetenciaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cupos { get; set; }
        public double Precio { get; set; }
        public string Tipo { get; set; }
    }
}
