using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Cobro
{
    public interface ICobroQuery
    {
        Task<Domain.Entities.Cobro> ConsultarCobro(int idCobro, CancellationToken ct = default);
    }
}
