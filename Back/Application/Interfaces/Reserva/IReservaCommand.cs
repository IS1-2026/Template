
using Domain.Entities;

namespace Application.Interfaces.Reserva
{
    public interface IReservaCommand
    {
        Task<Domain.Entities.Reserva> CrearReserva(Domain.Entities.Reserva Reserva,CancellationToken ct = default);
        Task<Domain.Entities.Reserva> ModificarReserva(Domain.Entities.Reserva Reserva, CancellationToken ct = default);
        Task<Domain.Entities.Reserva> EliminarReserva(Domain.Entities.Reserva Reserva, CancellationToken ct = default);
    }
}
