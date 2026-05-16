
using Application.DTOs.Request;
using Application.DTOs.Response;

namespace Application.Interfaces
{
    public interface ICanchaService
    {
         Task<CanchaResponse> CrearCancha(CrearCanchaRequest request);
    }
}
