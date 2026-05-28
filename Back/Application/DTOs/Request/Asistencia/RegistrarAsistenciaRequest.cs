

namespace Application.DTOs.Request.Asistencia
{
    public class RegistrarAsistenciaRequest
    {
        public int ClaseId { get; set; }
        public int DniCliente { get; set; }
        public bool Presente { get; set; }
    }
}
