using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Entrenamiento
{
     public interface IEntrenamientoQuery
    {
        Task<Domain.Entities.Entrenamiento> ConsultarEntrenamiento(int EntrenamientoId, CancellationToken ct = default);
        Task<Domain.Entities.Entrenamiento> ImprimirEntrenamiento(int EntrenamientoId, CancellationToken ct = default);
    }
}
