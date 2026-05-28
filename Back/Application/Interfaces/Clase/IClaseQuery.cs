

namespace Application.Interfaces.Clase
{
    public interface IClaseQuery
    {

        Task<Domain.Entities.Clase> ConsultarClase(int Clase, CancellationToken ct = default);
        Task<List<Domain.Entities.Inscripcion>> MostrarInscriptos(int claseId, CancellationToken ct = default);
        Task<Domain.Entities.Inscripcion> DevolverInscripto(int InscripcionId, CancellationToken ct = default);
        Task<List<Domain.Entities.Clase>> ListarClases(CancellationToken ct = default);
        Task<List<Domain.Entities.Clase>> VerClasesPorProfesor(int profesorDni,CancellationToken ct = default);
        
    }
}
