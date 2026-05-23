using Application.DTOs.Response.Asistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Asistencia
{
    public interface IAsistenciaQuery
    {

      Task<Domain.Entities.Asistencia> ConsultarAsistencia(int idAsistencia);

        Task<List<Domain.Entities.Asistencia>> ListarAsistencia(int idClase);

        
    }
}
