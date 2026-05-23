using Application.DTOs.Request.Asistencia;
using Application.DTOs.Response.Asistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Asistencia
{
    public interface IAsistenciaCommand
    {
        Task<Domain.Entities.Asistencia> EliminarAsistencia(Domain.Entities.Asistencia Asistencia, CancellationToken ct = default);
        Task<Domain.Entities.Asistencia> ModificarAsistencia(Domain.Entities.Asistencia Asistencia, CancellationToken ct = default);
        Task<Domain.Entities.Asistencia> RegistrarAsistencia(Domain.Entities.Asistencia Asistencia, CancellationToken ct = default);

        Task<Domain.Entities.Administrador> PasarAsistencia(ModificarAsistenciaRequest request);


    }
}
