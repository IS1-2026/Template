using Application.DTOs.Request.Profesional;
using Application.DTOs.Response.Profesional;
using Application.Interfaces.Profesionales;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.Profesional
{
    public class ProfesionalMapper : IProfesionalMapper
    {
        public async Task<Profesor> MapearProfesorRequestAEntidad(RegistrarProfesorRequest request)
        {
            if (request == null) return null;

            return await Task.FromResult(new Profesor
            {
                // Datos de la herencia de Usuario
                Dni = request.Dni,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Localidad = request.Localidad,
                Pais = request.Pais,
                Correo = request.Correo,
                Password = request.Password,
                FechaNac = request.FechaNac,

                // Dato de la herencia de Profesional
                Certificado = request.Certificado
            });
        }

        public async Task<Entrenador> MapearEntrenadorRequestAEntidad(RegistrarEntrenadorRequest request)
        {
            if (request == null) return null;

            return await Task.FromResult(new Entrenador
            {
                // Datos de la herencia de Usuario
                Dni = request.Dni,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Localidad = request.Localidad,
                Pais = request.Pais,
                Correo = request.Correo,
                Password = request.Password,
                FechaNac = request.FechaNac,

                // Dato de la herencia de Profesional
                Certificado = request.Certificado
            });
        }
        public async Task<ProfesorResponse> MapearProfesorEntidadAResponse(Profesor profesor)
        {
            if (profesor == null) return null;

            var response = new ProfesorResponse
            {
                // Datos heredados de UsuarioResponse
                Dni = profesor.Dni,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Localidad = profesor.Localidad,
                Pais = profesor.Pais,
                Correo = profesor.Correo,
                Estado = profesor.Estado,

                // Datos heredados de ProfesionalResponse
                Certificado = profesor.Certificado,
                EstaCertificado = profesor.EstaCertificado
            };

/*Mapeo para lo de las listas de entrenamientos
          if (profesor.Clases != null)
            {
                foreach (var clase in profesor.Clases)
                {
                    response.Clases.Add(new ClaseDto
                    {
                        IdClase = clase.IdClase,
                        Cupo = clase.Cupo,
                        Precio = clase.Precio,
                        IdProfesor = clase.IdProfesor
                    });
                }
            }*/

            return response;
        }

        public async Task<EntrenadorResponse> MapearEntrenadorEntidadAResponse(Entrenador entrenador)
        {
            if (entrenador == null) return null;

            var response = new EntrenadorResponse
            {
                // Datos heredados de UsuarioResponse
                Dni = entrenador.Dni,
                Nombre = entrenador.Nombre,
                Apellido = entrenador.Apellido,
                Localidad = entrenador.Localidad,
                Pais = entrenador.Pais,
                Correo = entrenador.Correo,
                Estado = entrenador.Estado,

                // Datos heredados de ProfesionalResponse
                Certificado = entrenador.Certificado,
                EstaCertificado = entrenador.EstaCertificado
            };
/*Mapeo para lo de las listas de entrenamientos
            if (entrenador.Entrenamientos != null)
            {
                foreach (var entrenamiento in entrenador.Entrenamientos)
                {
                    response.Entrenamientos.Add(new EntrenamientoDto
                    {
                        IdEntrenamiento = entrenamiento.IdEntrenamiento,
                        DniEntrenador = entrenamiento.DniEntrenador,
                        Precio = entrenamiento.Precio
                    });
                }
            }*/

            return response;
        }

        public async Task<List<ProfesorResponse>> ObtenerTodosProfesoresResponse(List<Profesor> profesores)
        {
            var lista = new List<ProfesorResponse>();
            if (profesores == null) return lista;

            foreach (var p in profesores)
            {
                lista.Add(await MapearProfesorEntidadAResponse(p));
            }
            return lista;
        }

        public async Task<List<EntrenadorResponse>> ObtenerTodosEntrenadoresResponse(List<Entrenador> entrenadores)
        {
            var lista = new List<EntrenadorResponse>();
            if (entrenadores == null) return lista;

            foreach (var e in entrenadores)
            {
                lista.Add(await MapearEntrenadorEntidadAResponse(e));
            }
            return lista;
        }

    }
}
