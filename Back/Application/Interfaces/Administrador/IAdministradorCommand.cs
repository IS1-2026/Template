
namespace Application.Interfaces.Administrador
{
    public interface IAdministradorCommand
    {
        Task<Domain.Entities.Administrador> CrearAdministrador(Domain.Entities.Administrador Administrador, CancellationToken ct = default);
    }
}
