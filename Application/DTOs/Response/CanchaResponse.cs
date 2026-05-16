

namespace Application.DTOs.Response
{
    public class CanchaResponse
    {
        public int IdCancha { get; set; }
        public TipoCanchaResponse tipoCancha { get; set; }
        public List<DateTime> Disponibilidad {  get; set; }

    }
}
