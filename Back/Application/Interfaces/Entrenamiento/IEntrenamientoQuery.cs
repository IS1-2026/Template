
namespace Application.Interfaces.Entrenamiento
{
    public interface IEntrenamientoQuery
    {
        Task<Domain.Entities.Entrenamiento> ConsultarEntrenamiento(int EntrenamientoId, CancellationToken ct = default);
        Task<Domain.Entities.Entrenamiento> ImprimirEntrenamiento(int EntrenamientoId, CancellationToken ct = default);
    }
}
