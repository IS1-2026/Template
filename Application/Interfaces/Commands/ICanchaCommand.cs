
using Domain.Entities;

namespace Application.Interfaces.Commands
{
    public interface ICanchaCommand
    {
        Task<Cancha> CrearCancha(Cancha cancha, CancellationToken ct = default);
    }
}
