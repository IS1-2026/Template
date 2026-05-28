
using Application.DTOs.Request.Cancha;
using Application.DTOs.Request.TipoCancha;
using Application.DTOs.Response.TipoCancha;

namespace Application.Interfaces.TipoCancha
{
    public interface ITipoCanchaService
    {
        Task<TipoCanchaResponse> CrearTipoCancha(CrearTipoCanchaRequest request);
        Task<List<TipoCanchaResponse>> ListarTipoCancha();

        Task<TipoCanchaResponse> EditarTipoCancha(int tipoCanchaId,ActualizarTipoCanchaRequest request);
    }
}
