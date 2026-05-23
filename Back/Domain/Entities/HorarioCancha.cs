
namespace Domain.Entities
{
    public class HorarioCancha
    {
        public int Id { get; set; }
        public int IdCancha { get; set; }
        public DayOfWeek Dia {get;set; }
        public TimeSpan HoraInicio {get;set; }
        public TimeSpan HoraFin { get;set; }
        //Relación
        public Cancha Cancha {get;set; }
    }
}
