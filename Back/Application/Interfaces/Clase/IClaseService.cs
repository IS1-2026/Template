using Application.DTOs.Request.Clase;
using Application.DTOs.Response.Clase;
using Application.DTOs.Response.Inscripcion;


namespace Application.Interfaces.Clase
{
    public interface IClaseService
    {
        Task<ClaseResponse> ModificarClase(ModificarClaseRequest request);
        Task<ClaseResponse> ConsultarClase(int claseId);     
        Task<ClaseResponse> ProgramarClase(ProgramarClasesRequest request);
        Task<ClaseResponse> EliminarClase(int claseId);
        Task<InscripcionResponse> DevolverInscripto(int InscripcionId);
        Task<int> ContarCuposLibres(int idActividad, int IdClase);
        }
}
