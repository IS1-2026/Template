

namespace Domain.Entities
{
    public  class Descuento
    {
        public int IdDescuento { get; set; }
        public double Valor { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
    }
}
