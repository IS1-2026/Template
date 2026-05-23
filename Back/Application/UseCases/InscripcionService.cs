using Application.DTOs.Request.Inscripcion;
using Application.DTOs.Response.Cancha;
using Application.DTOs.Response.Clase;
using Application.DTOs.Response.Inscripcion;
using Application.Exceptions;
using Application.Interfaces.Asistencia;
using Application.Interfaces.Cancha;
using Application.Interfaces.Clase;
using Application.Interfaces.Entrenamiento;
using Application.Interfaces.Incripcion;
using Application.Interfaces.Reserva;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public  class InscripcionService :IInscripcionService
    {

        private readonly IInscripcionCommand _inscripcionCommand;
        private readonly IInscripcionQuery _inscripcionQuery;
        private readonly IClaseQuery _claseQuery;
        private readonly IEntrenamientoQuery _entrenamientoQuery;
        private readonly IAsistenciaCommand _asistenciaCommand;
        
        

        public InscripcionService(
            IInscripcionCommand inscripcionCommand,
            IInscripcionQuery inscripcionQuery,
            IClaseQuery claseQuery,
            IEntrenamientoQuery entrenamientoQuery,
            IAsistenciaCommand asistenciaCommand
            
            )
        {
            _asistenciaCommand = asistenciaCommand;
            _inscripcionCommand = inscripcionCommand;
            _inscripcionQuery = inscripcionQuery;
            _claseQuery = claseQuery;
            _entrenamientoQuery = entrenamientoQuery;
        }


        public async Task<InscripcionResponse> ConsultarInscripcion(int inscripcionId) {

            var inscripcion = await _inscripcionQuery.ConsultarInscripcion(inscripcionId) ?? throw new ExceptionNotFound("Profesor no existe");

            return new InscripcionResponse
            {
                IdInscripcion = inscripcion.IdInscripcion,
                DniCliente = inscripcion.DniCliente,
                Horario = inscripcion.Horario,
                PrecioInscr = inscripcion.PrecioInscr,
                IdAct = inscripcion.IdAct,
                IdCancha = inscripcion.IdCancha,
                IdDescuento = inscripcion.IdDescuento,
                NroAct = inscripcion.NroAct,

            };




        }


        public async  Task<InscripcionResponse> AgregarInscripcion(AgregarInscripcionRequest request)
        {

            if (request == null)
            {
                throw new ExceptionBadRequest("Debe ingresar datos");
            }

            if (request.DniCliente <= 0 & request.NroAct <= 0 & request.IdAct <=0 & request.PrecioInscr <= 0 & request.IdInscripcion <= 0)
            {
                throw new ExceptionBadRequest("Ingrese valor valido");


            }
            //Validamos disponibilidad
            int Disponibilidad = await _inscripcionQuery.CuposEnNumeroActividad(request.IdAct, request.NroAct);

            if (Disponibilidad == 0) {

                throw new ExceptionBadRequest("No hay mas cupo,elija otra clase/entrenamiento");
            }

            


            var inscripcion = new Inscripcion
            {
                IdInscripcion = request.IdInscripcion,
                DniCliente = request.DniCliente,
                Horario = DateTime.Now, // o request.Horario si lo trae
                PrecioInscr = request.PrecioInscr,
                IdAct = request.IdAct,
                IdCancha = request.IdCancha,
                IdDescuento = request.IdDescuento,
                NroAct = request.NroAct
            };

            
            if (inscripcion.NroAct == 2)
            {
                var asistencia = new Asistencia {
                   
                   DniCliente = request.DniCliente,
                   IdClase = request.NroAct,
                    Presente = false
               };
                var asistenciaCreada = await _asistenciaCommand.RegistrarAsistencia(asistencia);
            }



            var InscripcionCreada = await _inscripcionCommand.AgregarInscripcion(inscripcion);


            return new InscripcionResponse
            {
                IdInscripcion = InscripcionCreada.IdInscripcion,
                DniCliente = InscripcionCreada.DniCliente,
                Horario = InscripcionCreada.Horario, // o request.Horario si lo trae
                PrecioInscr = InscripcionCreada.PrecioInscr,
                IdAct = InscripcionCreada.IdAct,
                IdCancha = InscripcionCreada.IdCancha,
                IdDescuento = InscripcionCreada.IdDescuento,
                NroAct =InscripcionCreada.NroAct

            };


        }


        public async Task<InscripcionResponse> EliminarInscripcion(int inscripcionId) {

            if (inscripcionId <= 0)
            {
                throw new ExceptionBadRequest("Debe ingresar un id valido");
            }

            var inscripcion = await _inscripcionQuery.ConsultarInscripcion(inscripcionId);

            if (inscripcion == null)
            {
                throw new ExceptionNotFound("Inscripcion no encontrada");
            }

            var inscripcionEliminada = await _inscripcionCommand.EliminarInscripcion(inscripcion);

            return new InscripcionResponse
            {
                IdInscripcion = inscripcionEliminada.IdInscripcion,

                IdAct = inscripcionEliminada.IdAct,

                IdCancha = inscripcionEliminada.IdCancha,

                DniCliente = inscripcionEliminada.DniCliente,

                Horario = inscripcionEliminada.Horario,

                PrecioInscr = inscripcionEliminada.PrecioInscr,

                NroAct= inscripcionEliminada.NroAct,

                IdDescuento= inscripcionEliminada.IdDescuento,




            };

        }

        public async Task<List<InscripcionResponse>> ListaDeInscriptos() {

            var inscripciones = await _inscripcionQuery.ListaDeInscriptos();


            return inscripciones.Select(inscripcion => new InscripcionResponse
            {



                IdInscripcion = inscripcion.IdInscripcion,
                DniCliente = inscripcion.DniCliente,
                Horario = inscripcion.Horario,
                PrecioInscr = inscripcion.PrecioInscr,
                NroAct = inscripcion.NroAct,
                IdAct = inscripcion.IdAct,
                IdCancha = inscripcion.IdCancha,
                IdDescuento = inscripcion.IdDescuento




            }).ToList();


        }




   


        public async Task<int> ContadorInscripcion(int idActividad, int nroActividad)
        {
            // Traer todas las inscripciones
            var inscripciones = await _inscripcionQuery.ListaDeInscriptos();

            // Filtrar por actividad y número de actividad
            var filtradas = inscripciones
                            .Where(i => i.IdAct == idActividad && i.NroAct == nroActividad)
                            .ToList();

            

            // Devolver el número de inscriptos
            return filtradas.Count;
        }

        public async Task<int> CuposEnNumeroActividad(int idActividad, int nroActividad)
        {
            int cuposTotales = 0;

            switch (idActividad)
            {
                case 1: // Entrenamiento
                    var entrenamiento = await _entrenamientoQuery.ConsultarEntrenamiento(nroActividad);
                    cuposTotales = entrenamiento.Cupo;
                    break;

                case 2: // Clase
                    var clase = await _claseQuery.ConsultarClase(nroActividad);
                    cuposTotales = clase.Cupo;
                    break;

                default:
                    throw new ExceptionBadRequest("Actividad no válida");
            }

            // Contar inscriptos filtrados por actividad y número
            int inscriptos = await _inscripcionQuery.ContadorInscripcion(idActividad, nroActividad);//consulta numeros de inscriptos de la clase/entrenamiento

            // Restar cupos totales - inscriptos
            return cuposTotales - inscriptos;
        }


        



        }









    }

