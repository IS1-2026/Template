using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.DTOs.Request.Equipos;
using Application.DTOs.Response.Equipos;

namespace Application.Interfaces.Equipos
{
    public interface IEquipoService
    {
        Task<int> CrearEquipo(CrearEquipoRequest request, CancellationToken ct = default);
        Task ModificarEquipo(ModificarEquipoRequest request, CancellationToken ct = default);
        Task EliminarEquipo(int idEquipo, CancellationToken ct = default);
        Task<EquipoResponse> ObtenerEquipoPorId(int id, CancellationToken ct = default);
        Task<IEnumerable<EquipoResponse>> ObtenerEquiposPorCompetencia(int competenciaId, CancellationToken ct = default);
        Task<bool> ExisteEquipo(int equipoId, CancellationToken ct = default);
    }

}

