namespace Application.Interfaces.Entrenamiento
{
    public interface IEntrenamientoCommand
    {
        Task<Domain.Entities.Entrenamiento> ProgramarEntrenamiento(Domain.Entities.Entrenamiento Entrenamiento, CancellationToken ct = default);
        Task<Domain.Entities.Entrenamiento> ModificarEntrenamiento(Domain.Entities.Entrenamiento Entrenamiento, CancellationToken ct = default);
        Task<Domain.Entities.Entrenamiento> EliminarEntrenamiento(Domain.Entities.Entrenamiento Entrenamiento, CancellationToken ct = default);
        Task<int> DecrementarCupo(int entrenamientoId, CancellationToken ct = default);
    }
}
