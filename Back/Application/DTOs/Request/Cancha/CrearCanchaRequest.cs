using Application.DTOs.Request.HorarioCancha;

namespace Application.DTOs.Request.Cancha
{
    public class CrearCanchaRequest
    {
        public int IdTipoCancha { get; set; }
        public string Nombre { get; set; }
        
        public List<CrearHorarioCanchaRequest> Horarios { get; set; }

    }
}
