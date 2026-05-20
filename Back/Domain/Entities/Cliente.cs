
using System.Collections;

namespace Domain.Entities
{
    public class Cliente:Usuario
    {
        public IEnumerable<Reserva> Reservas {  get; set; }
        public IEnumerable<Inscripcion> Inscripciones { get; set; }
        public bool EsSocio {  get; set; }
    }
}
