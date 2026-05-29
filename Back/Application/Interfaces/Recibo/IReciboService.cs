using Application.DTOs.Request.Recibo;
using Application.DTOs.Response.Recibo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Recibo
{
    public interface IReciboService
    {
        Task<ReciboResponse> RegistrarRecibo(RegistrarReciboRequest request, CancellationToken ct = default);
        Task<ReciboResponse> ModificarRecibo(ModificarReciboRequest request, CancellationToken ct = default);
        Task<ReciboResponse> ConsultarRecibo(int idRecibo, CancellationToken ct = default);
        Task<ReciboResponse> ImprimirRecibo(int idRecibo, CancellationToken ct = default);
        Task<bool> EliminarRecibo(EliminarReciboRequest request, CancellationToken ct = default);
    }
}