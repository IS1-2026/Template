using Application.DTOs.Request.Entrenamiento;
using Application.DTOs.Response.Entrenamiento;
using Application.Exceptions;
using Application.Interfaces.Entrenamiento;
using Application.Interfaces.Entrenamiento;
using Application.Interfaces.Reserva;
using Domain.Entities;
namespace Application.UseCases
{
    public class EntrenamientoService : IEntrenamientoService //Interfaz de entrenamiento service
    {
        private readonly IEntrenamientoCommand _entrenamientoCommand;
        private readonly IEntrenamientoQuery _entrenamientoQuery;


        public EntrenamientoService(
            IEntrenamientoCommand entrenamientoCommand,
            IEntrenamientoQuery entrenamientoQuery
            )

        {
            _entrenamientoCommand = entrenamientoCommand;
            _entrenamientoQuery = entrenamientoQuery;

        }

        public async Task<EntrenamientoResponse> ModificarEntrenamiento(ModificarEntrenamientoRequest request)
        {
            if (request == null)
            {
                throw new ExceptionBadRequest("Debe ingresar datos");
            }

            if (request.Precio > 0)
            {
                throw new ExceptionBadRequest("Debe ingresar datos");
            }
            

            var Entrenamiento = await _entrenamientoQuery.ConsultarEntrenamiento(request.Id_Entrenamiento);//hace referencia a la interfaz de EntrenamientoQuery 
            if (Entrenamiento== null)
            {
                throw new ExceptionNotFound("Entrenamiento no encontrado");
            }

            Entrenamiento.Precio = request.Precio;

            var entrenamientoActualizado = await _entrenamientoCommand.ModificarEntrenamiento(Entrenamiento);

            return new EntrenamientoResponse
            {
                Id_Entrenamiento = entrenamientoActualizado.IdEntrenamiento,
                Dni_Entrenador = entrenamientoActualizado.DniEntrenador,
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
               Id_Entrenamiento = Entrenamiento.IdEntrenamiento,
               Dni_Entrenador = Entrenamiento.DniEntrenador,
               Precio = Entrenamiento.Precio
            };
        }















        public async Task<EntrenamientoResponse> ProgramarEntrenamiento(ProgramarEntrenamientoRequest request)
        {
            var entrenamiento = new Entrenamiento
            {
                
                IdEntrenamiento= request.Id_Entrenamiento,
                DniEntrenador = request.Dni_Entrenador,
                Precio = request.Precio

            };

            var EntrenamientoProgramada = await _entrenamientoCommand.ProgramarEntrenamiento(entrenamiento);

            return new EntrenamientoResponse
            {
               Id_Entrenamiento = EntrenamientoProgramada.IdEntrenamiento,
               Dni_Entrenador = EntrenamientoProgramada.DniEntrenador,
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
                Id_Entrenamiento = entrenamiento.IdEntrenamiento,//sobreescribo
               Dni_Entrenador = entrenamiento.DniEntrenador,
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

                Id_Entrenamiento=EntrenamientoEliminada.IdEntrenamiento,
                Dni_Entrenador = EntrenamientoEliminada.DniEntrenador,
                Precio=EntrenamientoEliminada.Precio

            };


        }





















    }
}