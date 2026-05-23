using Application.DTOs.Request.Cancha;
using Application.DTOs.Request.HorarioCancha;
using Application.DTOs.Response.Cancha;
using Application.DTOs.Response.HorarioCancha;

namespace Application.Interfaces.Cancha
{
    public interface ICanchaService
    {
        Task<CanchaResponse> CrearCancha(CrearCanchaRequest request);
        Task<CanchaResponse> ModificarHorarioCancha(ActualizarHorarioCanchaRequest request);
        Task<CanchaResponse> ConsultarCancha(int CanchaId);
        Task<CanchaResponse> EliminarCancha(int CanchaId);
        Task<List<CanchaResponse>> ListarCanchas();
        Task<CanchaResponse> CambiarEstado(int CanchaId);
        Task<List<HorarioCanchaResponse>> VerDisponibilidad(int CanchaId,DateOnly fecha);
    }
}
