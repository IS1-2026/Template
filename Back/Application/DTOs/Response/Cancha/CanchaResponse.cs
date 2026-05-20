using Application.DTOs.Response.TipoCancha;

namespace Application.DTOs.Response.Cancha
{
    public class CanchaResponse
    {
        public int IdCancha { get; set; }
        public TipoCanchaResponse tipoCancha { get; set; }
        public List<TimeSpan> Disponibilidad {  get; set; }

    }
}
