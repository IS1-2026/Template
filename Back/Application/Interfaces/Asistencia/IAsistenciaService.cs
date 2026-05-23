using Application.DTOs.Request.Asistencia;
using Application.DTOs.Response.Asistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Asistencia
{
    public interface IAsistenciaService
    {
       
        
            Task<AsistenciaResponse> RegistrarAsistencia(RegistrarAsistenciaRequest request);
            Task<AsistenciaResponse> ModificarAsistencia(ModificarAsistenciaRequest request
                );
            Task<AsistenciaResponse> EliminarAsitencia(int IdAsistencia); // también faltaba el parámetro
            Task<AsistenciaResponse> ConsultarAsistencia(int IdAsistencia); // también faltaba
            Task<List<AsistenciaResponse>> ListarAsistencia(int idClase);
            Task<AsistenciaResponse> PasarAsistencia(ModificarAsistenciaRequest request);
        
    }
}
