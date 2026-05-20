using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Entrenamiento
{
    public interface IEntrenamientoCommand
    {
        Task<Domain.Entities.Entrenamiento> ProgramarEntrenamiento(Domain.Entities.Entrenamiento Entrenamiento, CancellationToken ct = default);
        Task<Domain.Entities.Entrenamiento> ModificarEntrenamiento(Domain.Entities.Entrenamiento Entrenamiento, CancellationToken ct = default);
        Task<Domain.Entities.Entrenamiento> EliminarEntrenamiento(Domain.Entities.Entrenamiento Entrenamiento, CancellationToken ct = default);
    }
}
