using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Recibo
{
    public interface IReciboCommand
    {
        Task<Domain.Entities.Recibo> RegistrarRecibo(Domain.Entities.Recibo recibo, CancellationToken ct = default);
        Task<Domain.Entities.Recibo> ModificarRecibo(Domain.Entities.Recibo recibo, CancellationToken ct = default);
        Task<Domain.Entities.Recibo> EliminarRecibo(Domain.Entities.Recibo recibo, CancellationToken ct = default);
    }
}
