namespace Application.DTOs.Response.HorarioCancha
{
    public class HorarioCanchaResponse
    {
        public int HorarioCanchaId { get; set; }
        public DayOfWeek Dia {  get; set; }
        public TimeSpan HoraInicio {  get; set; }
        public TimeSpan HoraFin {  get; set; }
        public bool Disponible { get; set; }
    }
}
