

using Domain.Entities;

namespace Application.Interfaces.HorarioCancha
{
    public interface IHorarioCanchaCommand
    {
        Task<Domain.Entities.HorarioCancha> CrearHorario(Domain.Entities.HorarioCancha horarioCancha,CancellationToken ct=default);
        Task<Domain.Entities.HorarioCancha> ModificarHorario(Domain.Entities.HorarioCancha horarioCancha, CancellationToken ct = default);
    }
}
