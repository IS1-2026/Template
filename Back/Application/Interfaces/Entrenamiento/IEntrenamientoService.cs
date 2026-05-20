using Application.DTOs.Request.Entrenamiento;
using Application.DTOs.Response.Entrenamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Entrenamiento
{
     public interface IEntrenamientoService
    {
        Task<EntrenamientoResponse> ModificarEntrenamiento(ModificarEntrenamientoRequest request);
        
        Task<EntrenamientoResponse> ImprimirEntrenamiento(int entrenamientoId);

        Task<EntrenamientoResponse> ConsultarEntrenamiento(int entrenamientoId);

       Task<EntrenamientoResponse> ProgramarEntrenamiento(ProgramarEntrenamientoRequest request);

        Task<EntrenamientoResponse> EliminarEntrenamiento(int entrenamientoId);

    }
}
