
namespace Application.DTOs.Response.HorarioCancha
{
    public class ReservaHorarioCanchaResponse
    {
        public int IdCanchaHorario { get; set; }

        public DateOnly Fecha { get; set; }

        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}
