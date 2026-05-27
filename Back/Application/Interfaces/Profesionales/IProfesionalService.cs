using Application.DTOs.Request.Cliente;
using Application.DTOs.Request.Profesional;
using Application.DTOs.Response.Profesional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Profesionales
{
    public interface IProfesionalService
    {
        // RF46: Registrar
        Task<ProfesorResponse> RegistrarProfesor(RegistrarProfesorRequest request);
        Task<EntrenadorResponse> RegistrarEntrenador(RegistrarEntrenadorRequest request);

        // RF47: Modificar
        Task<ProfesorResponse> ModificarProfesor(int dni, RegistrarProfesorRequest request);
        Task<EntrenadorResponse> ModificarEntrenador(int dni, RegistrarEntrenadorRequest request);

        // RF48: Consultar
        Task<ProfesorResponse> ConsultarProfesorPorDni(int dni);
        Task<EntrenadorResponse> ConsultarEntrenadorPorDni(int dni);
        Task<List<ProfesorResponse>> ConsultarTodosLosProfesores();
        Task<List<EntrenadorResponse>> ConsultarTodosLosEntrenadores();

        // RF49: Eliminar
        Task<bool> EliminarProfesor(int dni);
        Task<bool> EliminarEntrenador(int dni);

        // RF50: Imprimir 
        Task<string> ImprimirFichaProfesional(int dni, string tipoProfesional);

        // RF51: Asignar profesionales a clientes para clases particulares
        Task<bool> AsignarClienteAProfesional(int profesionalDni, int clienteId, double precio);

        // RF52: Verificar certificación deportiva
        Task<bool> VerificarCertificacion(int dni, string tipoProfesional, bool aprobado);

        //Logins
        Task<ProfesionalLoginResponse> ProfesorLogin(LoginRequest request);
        Task<ProfesionalLoginResponse> EntrenadorLogin(LoginRequest request);
    }
}
