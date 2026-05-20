
using Domain.Entities;

namespace Application.Interfaces.TipoCancha
{
    public interface ITipoCanchaQuery
    {
        Task<bool> ExisteTipoCancha(int id, CancellationToken ct = default);
        Task<Domain.Entities.TipoCancha> ObtenerTipoCancha(int id, CancellationToken ct = default);
    }
}
