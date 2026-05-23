
using System.Security.Cryptography.X509Certificates;

namespace Application.DTOs.Request.TipoCancha
{
    public class CrearTipoCanchaRequest
    {
        public string Nombre { get; set; }
        public string Superficie { get; set; }
        public int Capacidad { get; set; }
        public int Duracion { get; set; }
        public int Precio { get; set; }
    }
}
