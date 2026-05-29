
namespace Domain.Entities
{
    public class Inscripcion
    {
        public int IdInscripcion { get; set; }
        public int DniCliente { get; set; }
        public DateTime Horario { get; set; }
        public double PrecioInscr { get; set; }
        public int NroAct { get; set; } //1- Entrenamiento,2- Clase, 3- Competición, etc
        public int IdAct { get; set; }

        public int IdDescuento { get; set; }

        //Relaciones
        public Cliente cliente { get; set; }
        public Clase? clase { get; set; }
        public Cobro Cobro { get; set; }
        public Entrenamiento? entrenamiento { get; set; }
        public Competencia? competencia { get; set; }
       
    }

}
