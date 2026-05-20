

namespace Domain.Entities
{
    public class Usuario
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Localidad { get; set; }
        public string Pais { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public DateTime FechaNac {  get; set; }
        public bool Estado { get; set; }
    }
}
