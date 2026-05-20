using Domain.Entities;

namespace Application.Interfaces.Cancha
{
    public interface ICanchaCommand
    {
        Task<Domain.Entities.Cancha> CrearCancha(Domain.Entities.Cancha Cancha, CancellationToken ct = default);
        Task<Domain.Entities.Cancha> ModificarCancha(Domain.Entities.Cancha Cancha, CancellationToken ct = default);
        Task<Domain.Entities.Cancha> EliminarCancha(Domain.Entities.Cancha Cancha, CancellationToken ct = default);
        Task<Domain.Entities.Cancha> CambiarEstado(Domain.Entities.Cancha Cancha, CancellationToken ct = default);

    }
}
