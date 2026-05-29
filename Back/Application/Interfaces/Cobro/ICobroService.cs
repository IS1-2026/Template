using Application.DTOs.Request.Cobro;
using Application.DTOs.Response.Cobro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Cobro
{
    public interface ICobroService
    {
        Task<CobroResponse> RegistrarCobro(RegistrarCobroRequest request, CancellationToken ct = default);
        Task<CobroResponse> ModificarCobro(ModificarCobroRequest request, CancellationToken ct = default);
        Task<bool> EliminarCobro(EliminarCobroRequest request, CancellationToken ct = default);
        Task<CobroResponse> ConsultarCobro(int idCobro, CancellationToken ct = default);
        Task ImprimirCobro(int idCobro, CancellationToken ct = default);
    }
}
