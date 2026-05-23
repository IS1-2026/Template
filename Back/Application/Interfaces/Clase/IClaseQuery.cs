using Application.DTOs.Response.Asistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Clase
{
    public  interface IClaseQuery
    {
        
        Task<Domain.Entities.Clase> ConsultarClase(int Clase, CancellationToken ct = default);
        Task<List<Domain.Entities.Clase>> MostrarInscriptos(CancellationToken ct = default);

        Task<Domain.Entities.Inscripcion> DevolverInscripto(int InscripcionId, CancellationToken ct = default);

        
        
    }
}
