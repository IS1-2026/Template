using Application.DTOs.Response.HorarioCancha;
using Application.DTOs.Response.TipoCancha;

namespace Application.DTOs.Response.Cancha
{
    public class CanchaResponse
    {
        public int IdCancha { get; set; }
        public string Nombre { get; set; }
        public TipoCanchaResponse tipoCancha { get; set; }
        public List<HorarioCanchaResponse> Disponibilidad {  get; set; }

    }
}
