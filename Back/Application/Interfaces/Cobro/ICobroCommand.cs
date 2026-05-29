using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Cobro
{
    public interface ICobroCommand
    {
        Task<Domain.Entities.Cobro> RegistrarCobro(Domain.Entities.Cobro cobro, CancellationToken ct = default);
        Task<Domain.Entities.Cobro> ModificarCobro(Domain.Entities.Cobro cobro, CancellationToken ct = default);
        Task<Domain.Entities.Cobro> EliminarCobro(Domain.Entities.Cobro cobro, CancellationToken ct = default);
    }
}
