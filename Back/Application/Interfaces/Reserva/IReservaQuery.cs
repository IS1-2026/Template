
namespace Application.Interfaces.Reserva
{
    public interface IReservaQuery
    {
        Task<Domain.Entities.Reserva> ConsultarReserva(int ReservaId, CancellationToken ct = default);
        Task<List<Domain.Entities.Reserva>> ListarReservas(CancellationToken ct = default);

    }
}
