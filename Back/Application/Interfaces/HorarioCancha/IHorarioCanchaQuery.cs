namespace Application.Interfaces.HorarioCancha
{
    public interface IHorarioCanchaQuery
    {
        Task<Domain.Entities.HorarioCancha> ConsultarHorarioCancha(int IdHorarioCancha, CancellationToken ct = default);
    }
}
