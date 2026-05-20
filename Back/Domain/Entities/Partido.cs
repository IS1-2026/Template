
namespace Domain.Entities
{
    public class Partido
    {
        public int IdPartido { get; set; }
        public int IdCompetencia { get; set; }
        public int IdEquipoLocal { get; set; }
        public int IdEquipoVis {  get; set; }
        public string Resultado { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin {  get; set; }

        //Relaciones

        public Equipo EquipoLocal { get; set; }
        public Equipo EquipoVis { get; set; }
        public Competencia Competencia { get; set; }
    }
}
