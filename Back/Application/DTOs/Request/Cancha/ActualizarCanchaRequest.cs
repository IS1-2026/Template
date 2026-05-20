namespace Application.DTOs.Request.Cancha
{
    public class ActualizarCanchaRequest
    {
        public int CanchaId { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin {  get; set; }
    }
}
