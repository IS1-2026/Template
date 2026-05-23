using Application.DTOs.Response.Inscripcion;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Incripcion
{
    public interface IInscripcionCommand
    {
        

        Task<Domain.Entities.Inscripcion> AgregarInscripcion(Domain.Entities.Inscripcion Inscricion, CancellationToken ct = default);


         Task<Domain.Entities.Inscripcion> EliminarInscripcion(Domain.Entities.Inscripcion Inscricion, CancellationToken ct = default);
    }
}
