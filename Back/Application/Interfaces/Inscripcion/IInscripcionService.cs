using Application.DTOs.Request.Clase;
using Application.DTOs.Request.Inscripcion;
using Application.DTOs.Response.Asistencia;
using Application.DTOs.Response.Clase;
using Application.DTOs.Response.Inscripcion;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Incripcion
{
    public interface IInscripcionService
    {
        
  

        Task<InscripcionResponse> ConsultarInscripcion(int inscripcionId);


        Task<InscripcionResponse> AgregarInscripcion(AgregarInscripcionRequest request);


        Task<InscripcionResponse> EliminarInscripcion(int claseId);

        Task<List<InscripcionResponse>> ListaDeInscriptos();

        Task<int> ContadorInscripcion(int idActividad, int nroActividad);

        Task<int> CuposEnNumeroActividad(int idActividad, int nroActividad);

        

        
    }
}
