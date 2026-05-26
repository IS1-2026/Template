

namespace Application.DTOs.Request.TipoCancha
{
    public class ActualizarTipoCanchaRequest
    {
        public string? Nombre { get; set; }
        public string? Superficie { get; set; }
        public int? Capacidad { get; set; }
        public int? Duracion { get; set; }
        public int? Precio { get; set; }
    }
}
