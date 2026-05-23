
namespace Application.DTOs.Request.HorarioCancha
{
    public class CrearHorarioCanchaRequest
    {
        public DayOfWeek Dia { get; set;}
        public TimeSpan HoraInicio { get; set;}
        public TimeSpan HoraFin { get; set;}
    }

}
