using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Profesionales
{
    public interface IProfesionalQuery
    {
        Task<Profesor> ObtenerProfesorPorId(int id);
        Task<Entrenador> ObtenerEntrenadorPorId(int id);
        Task<List<Profesor>> ObtenerTodosLosProfesores();
        Task<List<Entrenador>> ObtenerTodosLosEntrenadores();
        Task<Profesor> ProfesorLogin(string correo, CancellationToken ct = default);
        Task<Entrenador> EntrenadorLogin(string correo, CancellationToken ct = default);
    }
}
