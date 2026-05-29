using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Recibo
{
    public interface IReciboQuery
    {
        Task<Domain.Entities.Recibo> ConsultarRecibo(int idRecibo, CancellationToken ct = default);
        Task<Domain.Entities.Recibo> ImprimirRecibo(int idRecibo, CancellationToken ct = default);
    }
}
