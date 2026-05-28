using Application.DTOs.Request.Entrenamiento;
using Application.DTOs.Response.Entrenamiento;
using Application.Exceptions;
using Application.Interfaces.Entrenamiento;
using Application.Interfaces.Entrenamiento;
using Application.Interfaces.Profesionales;
using Application.Interfaces.Reserva;
using Domain.Entities;
namespace Application.UseCases
{
    public class EntrenamientoService : IEntrenamientoService //Interfaz de entrenamiento service
    {
        private readonly IEntrenamientoCommand _entrenamientoCommand;
        private readonly IEntrenamientoQuery _entrenamientoQuery;
        private readonly IProfesionalQuery _profesionalQuery;
        


        public EntrenamientoService(
            IEntrenamientoCommand entrenamientoCommand,
            IEntrenamientoQuery entrenamientoQuery,
            IProfesionalQuery profesionalQuery
            )

        {
            _entrenamientoCommand = entrenamientoCommand;
            _entrenamientoQuery = entrenamientoQuery;
            _profesionalQuery = profesionalQuery;

        }
        public async Task<EntrenamientoResponse> ModificarEntrenamiento(int entrenamientoId,ModificarEntrenamientoRequest request)
        {
            if (request == null)
            {
                throw new ExceptionBadRequest("Debe ingresar datos");
            }

            if (request.Precio <= 0)
            {
                throw new ExceptionBadRequest("Ingrese un precio válido");
            }

            

            var entrenamiento = await _entrenamientoQuery
                .ConsultarEntrenamiento(entrenamientoId);

            if (entrenamiento == null)
            {
                throw new ExceptionNotFound("Entrenamiento no encontrado");
            }

            var entrenador = await _profesionalQuery.ObtenerEntrenadorPorId((int)request.Dni_Entrenador);

            if (entrenador == null)
            {
                throw new ExceptionNotFound("El entrenador no existe");
            }
            entrenamiento.Nombre = request.Nombre ?? entrenamiento.Nombre;
            entrenamiento.Precio = (int)request.Precio;
            entrenamiento.DniEntrenador = (int)request.Dni_Entrenador;
            entrenamiento.Entrenador = entrenador;

            var entrenamientoActualizado = await _entrenamientoCommand.ModificarEntrenamiento(entrenamiento);

            return new EntrenamientoResponse
            {
                Nombre = entrenamiento.Nombre,
                Id_Entrenamiento = entrenamientoActualizado.IdEntrenamiento,
                Dni_Entrenador = entrenamientoActualizado.DniEntrenador,
                Cupo = entrenamientoActualizado.Cupo,
                Precio = entrenamientoActualizado.Precio
            };
        }
        public async Task<EntrenamientoResponse> ConsultarEntrenamiento(int entrenamientoId)
        {
            if (entrenamientoId <= 0)
            {
                throw new ExceptionBadRequest("Debe ingresar un id valido");

            }

            var Entrenamiento = await _entrenamientoQuery.ConsultarEntrenamiento(entrenamientoId);

            if (Entrenamiento == null)
            {
                throw new ExceptionNotFound("Entrenamiento no encontrada");
            }


            return new EntrenamientoResponse
            {
                Nombre=Entrenamiento.Nombre,
               Id_Entrenamiento = Entrenamiento.IdEntrenamiento,
               Dni_Entrenador = Entrenamiento.DniEntrenador,
               Precio = Entrenamiento.Precio
            };
        }
        public async Task<EntrenamientoResponse> ProgramarEntrenamiento(ProgramarEntrenamientoRequest request)
        {

            if (String.IsNullOrEmpty(request.Nombre)) 
            {
                throw new ExceptionBadRequest("Debe ingresar un nombre del entrenamiento");
            }
            if (request.Precio <= 0) 
            {
                throw new ExceptionBadRequest("Debe ingresar un precio valido");
            }
            if (request.Cupo <= 0) 
            {
                throw new ExceptionBadRequest("Debe ingresar un cupo valido");
            }
            if(request.Dni_Entrenador==null || request.Dni_Entrenador == 0) 
            {
                throw new ExceptionBadRequest("Ingrese un entrenador valido");
            }

            var entrenador = await _profesionalQuery.ObtenerEntrenadorPorId(request.Dni_Entrenador);
            if (entrenador == null)
            {
                throw new ExceptionNotFound("No se encontró el entrenador");
            }

            var entrenamiento = new Entrenamiento
            {
                Nombre = request.Nombre,
                DniEntrenador = request.Dni_Entrenador,
                Cupo= request.Cupo,
                Precio = request.Precio,
                IdActividad=1,
                Entrenador=entrenador
            };

            var EntrenamientoProgramada = await _entrenamientoCommand.ProgramarEntrenamiento(entrenamiento);

            return new EntrenamientoResponse
            {
                Nombre=EntrenamientoProgramada.Nombre,
               Id_Entrenamiento = EntrenamientoProgramada.IdEntrenamiento,
               Dni_Entrenador = EntrenamientoProgramada.DniEntrenador,
               Cupo = EntrenamientoProgramada.Cupo,               
               Precio = EntrenamientoProgramada.Precio
            };

        }
        public async Task<EntrenamientoResponse> ImprimirEntrenamiento(int entrenamientoId)
        {
            if (entrenamientoId <= 0)
            {
                throw new ExceptionBadRequest("Debe ingresar un id valido");//este es error por mal ingreso de datos
            }

            var entrenamiento = await _entrenamientoQuery.ConsultarEntrenamiento(entrenamientoId);//hace referencia a la intefaz de entrenamiento query(lo tengo que hacer)

            if (entrenamiento == null)
            {
                throw new ExceptionNotFound("Entrenamiento no encontrada");//este es error dentro del istema 
            }

            return new EntrenamientoResponse
            {
                Nombre=entrenamiento.Nombre,    
               Id_Entrenamiento = entrenamiento.IdEntrenamiento,//sobreescribo
               Dni_Entrenador = entrenamiento.DniEntrenador,
               Cupo= entrenamiento.Cupo,
               Precio = entrenamiento.Precio
            };
        }
        public async Task<EntrenamientoResponse> EliminarEntrenamiento(int entrenamientoId) {

            if(entrenamientoId <= 0)
            {
                throw new ExceptionBadRequest("Debe ingresar un id valido");
            }

            var entrenamiento = await _entrenamientoQuery.ConsultarEntrenamiento(entrenamientoId);

            if (entrenamiento == null)
            {
                throw new ExceptionNotFound("Reserva no encontrada");
            }

            var EntrenamientoEliminada = await _entrenamientoCommand.EliminarEntrenamiento(entrenamiento);


            return new EntrenamientoResponse
            {
                Nombre= entrenamiento.Nombre,
                Cupo=entrenamiento.Cupo,
                Id_Entrenamiento=EntrenamientoEliminada.IdEntrenamiento,
                Dni_Entrenador = EntrenamientoEliminada.DniEntrenador,
                Precio=EntrenamientoEliminada.Precio

            };


        }
        public async Task<List<EntrenamientoFullResponse>> ListarEntrenamientos()
        {
            var result = await _entrenamientoQuery.ListarEntrenamientos();
            return result.Select(entrenamiento => new EntrenamientoFullResponse
            {
               Nombre= entrenamiento.Nombre,
               Id_Entrenamiento=entrenamiento.IdEntrenamiento,
               Profesional= new DTOs.Response.Profesional.ProfesionalResponse 
               {
                Dni=entrenamiento.Entrenador.Dni,
                Nombre=entrenamiento.Entrenador.Nombre,
                Apellido=entrenamiento.Entrenador.Apellido,
                Localidad=entrenamiento.Entrenador.Localidad,
                Pais=entrenamiento.Entrenador.Pais,
                Correo=entrenamiento.Entrenador.Correo,
                Estado=entrenamiento.Entrenador.Estado,
                Certificado=entrenamiento.Entrenador.Certificado,
                EstaCertificado=entrenamiento.Entrenador.EstaCertificado
               },
               Cupo=entrenamiento.Cupo,
               Precio=entrenamiento.Precio,

            }).ToList();
        }

        public async Task<List<EntrenamientoResponse>> ListarEntrenamientosPorDni(int entrenadorDni)
        {
            var entrenador = await _profesionalQuery.ObtenerEntrenadorPorId(entrenadorDni) ?? throw new ExceptionNotFound("El entrador no fue encontrado");

            var entrenamientos = await _entrenamientoQuery.ListarEntrenamientosPorEntrenador(entrenador.Dni);

            return entrenamientos.Select(entrenamiento => new EntrenamientoResponse
            {
                Nombre = entrenamiento.Nombre,
                Id_Entrenamiento = entrenamiento.IdEntrenamiento,
                Dni_Entrenador = entrenamiento.DniEntrenador,
                Cupo = entrenamiento.Cupo,
                Precio = entrenamiento.Precio
            }).ToList();

        }
    }
}