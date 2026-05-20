
using Domain.Entities;

namespace Application.Interfaces.Cancha
{
    public interface ICanchaQuery
    {
        Task<Domain.Entities.Cancha> ConsultarCancha(int CanchaId,CancellationToken ct = default);
        Task<List<Domain.Entities.Cancha>> ListarCanchas(CancellationToken ct = default);
    }
}
