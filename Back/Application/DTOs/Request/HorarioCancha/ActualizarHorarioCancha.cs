

namespace Application.DTOs.Request.HorarioCancha
{
    public class ActualizarHorarioCanchaRequest
    {
        public int CanchaId { get; set; }

        public DayOfWeek Dia { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFin { get; set; }
    }
}
