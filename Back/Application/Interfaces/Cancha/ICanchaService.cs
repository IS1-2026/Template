using Application.DTOs.Request.Cancha;
using Application.DTOs.Response.Cancha;

namespace Application.Interfaces.Cancha
{
    public interface ICanchaService
    {
        Task<CanchaResponse> CrearCancha(CrearCanchaRequest request);
        Task<CanchaResponse> ModificarCancha(ActualizarCanchaRequest request);
        Task<CanchaResponse> ConsultarCancha(int CanchaId);
        Task<CanchaResponse> EliminarCancha(int CanchaId);
        Task<List<CanchaResponse>> ListarCanchas();
        Task<CanchaResponse> CambiarEstado(int CanchaId);
    }
}
