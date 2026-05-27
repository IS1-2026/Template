using Application.DTOs.Response.Clase;

namespace Application.DTOs.Response.Profesional
{
    public class ProfesorResponse : ProfesionalResponse
    {
        public List<ClaseResponse> Clases { get; set; } = new List<ClaseResponse>();
    }
}
