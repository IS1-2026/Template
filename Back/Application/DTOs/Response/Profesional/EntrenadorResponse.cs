using Application.DTOs.Response.Entrenamiento;


namespace Application.DTOs.Response.Profesional
{
    public class EntrenadorResponse : ProfesionalResponse
    {

        public List<EntrenamientoResponse> Entrenamientos { get; set; } = new List<EntrenamientoResponse>();

    }
}
