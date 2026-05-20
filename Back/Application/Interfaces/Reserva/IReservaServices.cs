using Application.DTOs.Request.Reserva;
using Application.DTOs.Response.Reserva;

namespace Application.Interfaces.Reserva
{
    public interface IReservaServices
    {
        Task<ReservaResponse> CrearReserva(CrearReservaRequest request);
        Task<ReservaResponse> ModificarReserva(ActualizarReservaRequest request);
        Task<ReservaResponse> ConsultarReserva(int ReservaId);
        Task<ReservaResponse> EliminarReserva(int ReservaId);
        Task<List<ReservaResponse>> ListarReservas();
    }
}
