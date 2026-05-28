
namespace Domain.Entities
{
    public class Asistencia
    {
        public int IdAsistencia { get; set; }
        public int DniCliente { get; set; }
        public int IdClase { get; set; }
        public bool Presente { get; set; } // True = Presente, False = Ausente
    }
}
