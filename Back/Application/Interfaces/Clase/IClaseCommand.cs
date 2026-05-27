using Application.DTOs.Response.Asistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Clase
{
    public interface IClaseCommand
    {

        Task<Domain.Entities.Clase> ProgramarClase(Domain.Entities.Clase Clase, CancellationToken ct = default);
        Task<Domain.Entities.Clase> ModificarClase(Domain.Entities.Clase Clase, CancellationToken ct = default);
        Task<Domain.Entities.Clase> EliminarClase(Domain.Entities.Clase Clase, CancellationToken ct = default);
        Task<Domain.Entities.Asistencia> PasarAsistencia(Domain.Entities.Clase Clase, CancellationToken ct = default);
        Task<int> DecrementarCupo(int claseId,CancellationToken ct = default);
    }
}
