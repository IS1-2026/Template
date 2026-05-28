

namespace Application.Interfaces.TipoCancha
{
    public interface ITipoCanchaCommand
    {
        Task<Domain.Entities.TipoCancha> CrearTipoCancha(Domain.Entities.TipoCancha TipoCancha, CancellationToken ct = default);
        Task<Domain.Entities.TipoCancha> ActualizarTipoCancha(Domain.Entities.TipoCancha TipoCancha, CancellationToken ct = default);
    }
}
