using Application.DTOs.Request.Asistencia;
using Application.DTOs.Request.Clase;
using Application.DTOs.Response.Asistencia;
using Application.DTOs.Response.Clase;
using Application.DTOs.Response.Inscripcion;


namespace Application.Interfaces.Clase
{
    public interface IClaseService
    {
        Task<ClaseResponse> ModificarClase(int claseId,ModificarClaseRequest request);
        Task<ClaseResponse> ConsultarClase(int claseId);     
        Task<ClaseResponse> ProgramarClase(ProgramarClasesRequest request);
        Task<ClaseResponse> EliminarClase(int claseId);
        Task<List<FullClaseResponse>> ListarClases();
        Task<InscripcionResponse> DevolverInscripto(int InscripcionId);
        Task<int> ContarCuposLibres(int idActividad, int IdClase);
        Task<List<AsistenciaResponse>> RegistrarAsistencia(int claseId,List<RegistrarAsistenciaRequest> request);
        Task<List<InscripcionResponse>> VerInscriptos(int claseId);
        
            
    
    }
}
