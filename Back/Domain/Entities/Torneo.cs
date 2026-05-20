

namespace Domain.Entities
{
    public class Torneo:Competencia
    {
        public List<string> Llaves { get; set; }
        public string FaseAct { get; set; }
    }
}
