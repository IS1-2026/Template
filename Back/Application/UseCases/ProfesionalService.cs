using Application.DTOs.Request.Cliente;
using Application.DTOs.Request.Profesional;
using Application.DTOs.Response;
using Application.DTOs.Response.Profesional;
using Application.Exceptions;
using Application.Interfaces.Profesionales;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class ProfesionalService : IProfesionalService
    {
        private readonly IProfesionalCommand _command;
        private readonly IProfesionalQuery _query;
        private readonly IProfesionalMapper _mapper;

        public ProfesionalService(IProfesionalCommand command, IProfesionalQuery query, IProfesionalMapper mapper)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
            _query = query ?? throw new ArgumentNullException(nameof(query));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ProfesorResponse> RegistrarProfesor(RegistrarProfesorRequest request)
        {
            if (request == null) throw new ExceptionBadRequest("La petición no puede ser nula.");
            if (request.Dni <= 0) throw new ExceptionBadRequest("El DNI debe ser mayor a cero.");

            var profesor = await _mapper.MapearProfesorRequestAEntidad(request);

            profesor.Estado = true;
            profesor.EstaCertificado = false;

            var resultado = await _command.RegistrarProfesor(profesor);
            return await _mapper.MapearProfesorEntidadAResponse(resultado);
        }

        public async Task<EntrenadorResponse> RegistrarEntrenador(RegistrarEntrenadorRequest request)
        {
            if (request == null) throw new ExceptionBadRequest("La petición no puede ser nula.");
            if (request.Dni <= 0) throw new ExceptionBadRequest("El DNI debe ser mayor a cero.");

            var entrenador = await _mapper.MapearEntrenadorRequestAEntidad(request);

            entrenador.Estado = true;
            entrenador.EstaCertificado = false;

            var resultado = await _command.RegistrarEntrenador(entrenador);
            return await _mapper.MapearEntrenadorEntidadAResponse(resultado);
        }

        public async Task<ProfesorResponse> ModificarProfesor(int dni, RegistrarProfesorRequest request)
        {
            if (dni <= 0) throw new ExceptionBadRequest("DNI inválido.");

            var profesorExistente = await _query.ObtenerProfesorPorId(dni);
            if (profesorExistente == null) throw new ExceptionNotFound("El profesor no existe.");

            profesorExistente.Localidad = request.Localidad;
            profesorExistente.Pais = request.Pais;
            profesorExistente.Correo = request.Correo;

            await _command.ModificarProfesor(profesorExistente);
            return await _mapper.MapearProfesorEntidadAResponse(profesorExistente);
        }

        public async Task<EntrenadorResponse> ModificarEntrenador(int dni, RegistrarEntrenadorRequest request)
        {
            if (dni <= 0) throw new ExceptionBadRequest("DNI inválido.");

            var entrenadorExistente = await _query.ObtenerEntrenadorPorId(dni);
            if (entrenadorExistente == null) throw new ExceptionNotFound("El entrenador no existe.");

            entrenadorExistente.Localidad = request.Localidad;
            entrenadorExistente.Pais = request.Pais;
            entrenadorExistente.Correo = request.Correo;

            await _command.ModificarEntrenador(entrenadorExistente);
            return await _mapper.MapearEntrenadorEntidadAResponse(entrenadorExistente);
        }

        public async Task<ProfesorResponse> ConsultarProfesorPorDni(int dni)
        {
            if (dni <= 0) throw new ExceptionBadRequest("El DNI debe ser válido.");

            var profesor = await _query.ObtenerProfesorPorId(dni);
            if (profesor == null) throw new ExceptionNotFound("Profesor no encontrado.");

            return await _mapper.MapearProfesorEntidadAResponse(profesor);
        }

        public async Task<EntrenadorResponse> ConsultarEntrenadorPorDni(int dni)
        {
            if (dni <= 0) throw new ExceptionBadRequest("El DNI debe ser válido.");

            var entrenador = await _query.ObtenerEntrenadorPorId(dni);
            if (entrenador == null) throw new ExceptionNotFound("Entrenador no encontrado.");

            return await _mapper.MapearEntrenadorEntidadAResponse(entrenador);
        }

        public async Task<List<ProfesorResponse>> ConsultarTodosLosProfesores()
        {
            var profesores = await _query.ObtenerTodosLosProfesores();
            return await _mapper.ObtenerTodosProfesoresResponse(profesores);
        }

        public async Task<List<EntrenadorResponse>> ConsultarTodosLosEntrenadores()
        {
            var entrenadores = await _query.ObtenerTodosLosEntrenadores();
            return await _mapper.ObtenerTodosEntrenadoresResponse(entrenadores);
        }

        public async Task<bool> EliminarProfesor(int dni)
        {
            if (dni <= 0) throw new ExceptionBadRequest("DNI inválido.");

            var profesor = await _query.ObtenerProfesorPorId(dni);
            if (profesor == null) throw new ExceptionNotFound("Profesor no encontrado.");

            return await _command.EliminarProfesional(dni);
        }

        public async Task<bool> EliminarEntrenador(int dni)
        {
            if (dni <= 0) throw new ExceptionBadRequest("DNI inválido.");

            var entrenador = await _query.ObtenerEntrenadorPorId(dni);
            if (entrenador == null) throw new ExceptionNotFound("Entrenador no encontrado.");

            return await _command.EliminarProfesional(dni);
        }

        public async Task<string> ImprimirFichaProfesional(int dni, string tipoProfesional)
        {
            if (dni <= 0) throw new ExceptionBadRequest("DNI inválido.");

            if (tipoProfesional.Equals("Profesor", StringComparison.OrdinalIgnoreCase))
            {
                var profesor = await _query.ObtenerProfesorPorId(dni);
                if (profesor == null) throw new ExceptionNotFound("No se encontró el profesor.");

                var response = await _mapper.MapearProfesorEntidadAResponse(profesor);

                return System.Text.Json.JsonSerializer.Serialize(response);
            }
            else if (tipoProfesional.Equals("Entrenador", StringComparison.OrdinalIgnoreCase))
            {
                var entrenador = await _query.ObtenerEntrenadorPorId(dni);
                if (entrenador == null) throw new ExceptionNotFound("No se encontró el entrenador.");

                var response = await _mapper.MapearEntrenadorEntidadAResponse(entrenador);

                return System.Text.Json.JsonSerializer.Serialize(response);
            }

            throw new ExceptionBadRequest("El tipo de profesional no es válido.");
        }

        public async Task<bool> AsignarClienteAProfesional(int profesionalDni, int clienteId, double precio)
        {
            if (profesionalDni <= 0 || clienteId <= 0) throw new ExceptionBadRequest("Los identificadores deben ser válidos.");

            var profesor = await _query.ObtenerProfesorPorId(profesionalDni);
            if (profesor != null)
            {
                if (!profesor.EstaCertificado)
                    throw new ExceptionConflict("El profesor no tiene habilitada la certificación deportiva.");

                var nuevaClase = new Domain.Entities.Clase
                {
                    DniProfesor = profesor.Dni,
                    Cupo = 1,
                    Precio = precio,
                    Inscripto = new List<Inscripcion> { new Inscripcion { DniCliente = clienteId } },
                    IdActividad = 1
                };

                var resultadoClase = await _command.InsertarClase((dynamic)nuevaClase); 
                return resultadoClase != null;
            }

            var entrenador = await _query.ObtenerEntrenadorPorId(profesionalDni);
            if (entrenador != null)
            {
                if (!entrenador.EstaCertificado)
                    throw new ExceptionConflict("El entrenador no está avalado con certificación deportiva.");

                var nuevoEntrenamiento = new Entrenamiento
                {
                    DniEntrenador = entrenador.Dni,
                    Precio = precio,
                    Inscriptos = new List<Inscripcion> { new Inscripcion { DniCliente = clienteId } }
                };

                var resultadoEntrenamiento = await _command.InsertarEntrenamiento(nuevoEntrenamiento);
                return resultadoEntrenamiento != null;
            }

            throw new ExceptionNotFound("No se encontró ningún profesional activo con el DNI especificado.");
        }

        public async Task<bool> VerificarCertificacion(int dni, string tipoProfesional, bool aprobado)
        {
            if (dni <= 0) throw new ExceptionBadRequest("DNI inválido.");

            if (tipoProfesional.Equals("Profesor", StringComparison.OrdinalIgnoreCase))
            {
                var profesor = await _query.ObtenerProfesorPorId(dni);
                if (profesor == null) throw new ExceptionNotFound("Profesor no encontrado.");

                profesor.EstaCertificado = aprobado;
                var resultado = await _command.ModificarProfesor(profesor);
                return resultado != null;
            }
            else if (tipoProfesional.Equals("Entrenador", StringComparison.OrdinalIgnoreCase))
            {
                var entrenador = await _query.ObtenerEntrenadorPorId(dni);
                if (entrenador == null) throw new ExceptionNotFound("Entrenador no encontrado.");

                entrenador.EstaCertificado = aprobado;
                var resultado = await _command.ModificarEntrenador(entrenador);
                return resultado != null;
            }

            throw new ExceptionBadRequest("El tipo de profesional no es válido.");
        }

        public async Task<ProfesionalLoginResponse> ProfesorLogin(LoginRequest request)
        {
            if (String.IsNullOrEmpty(request.Correo))
            {
                throw new ExceptionBadRequest("Complete el campo correo");
            }
            if (String.IsNullOrEmpty(request.Password))
            {
                throw new ExceptionBadRequest("Complete el campo contraseña");
            }

            var profesor = await _query.ProfesorLogin(request.Correo);

           

            return new ProfesionalLoginResponse
            {
                Dni = profesor.Dni,
                Nombre = profesor.Nombre,
                Correo = profesor.Correo,
            };
        }

        public async Task<ProfesionalLoginResponse> EntrenadorLogin(LoginRequest request)
        {
            if (String.IsNullOrEmpty(request.Correo))
            {
                throw new ExceptionBadRequest("Complete el campo correo");
            }
            if (String.IsNullOrEmpty(request.Password))
            {
                throw new ExceptionBadRequest("Complete el campo contraseña");
            }

            var entrenador = await _query.EntrenadorLogin(request.Correo);

           

            return new ProfesionalLoginResponse
            {
                Dni = entrenador.Dni,
                Nombre = entrenador.Nombre,
                Correo = entrenador.Correo,
            };
        }
    }
}
