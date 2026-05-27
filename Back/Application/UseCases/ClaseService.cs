using Application.DTOs.Request.Asistencia;
using Application.DTOs.Request.Clase;
using Application.DTOs.Response.Asistencia;
using Application.DTOs.Response.Clase;
using Application.DTOs.Response.Inscripcion;
using Application.Exceptions;
using Application.Interfaces.Asistencia;
using Application.Interfaces.Clase;
using Application.Interfaces.Entrenamiento;
using Application.Interfaces.Incripcion;
using Domain.Entities;


namespace Application.UseCases
{
    public  class ClaseService : IClaseService
    {

        private readonly IClaseCommand _claseCommand;
        private readonly IClaseQuery _claseQuery;
       
        private readonly IInscripcionQuery _inscripcionQuery;
        private readonly IAsistenciaCommand _asistenciaCommand;
        private readonly IAsistenciaQuery _asistenciaQuery;

        public ClaseService(
            IClaseCommand claseCommand,
            IClaseQuery claseQuery,
            
             IInscripcionQuery inscripcionQuery,
             IAsistenciaCommand asistenciaCommand,
             IAsistenciaQuery asistenciaQuery
            )
        {
            _asistenciaQuery = asistenciaQuery;
            _inscripcionQuery = inscripcionQuery;
            _claseCommand = claseCommand;
            _claseQuery = claseQuery;
            _asistenciaCommand = asistenciaCommand;


        }


        public async Task<ClaseResponse> ProgramarClase(ProgramarClasesRequest request)
        {


            if (request == null)
            {
                throw new ExceptionBadRequest("Debe ingresar datos");
            }

            if (request.Cupo <= 0)
            {
                throw new ExceptionBadRequest("Debe ingresar un cupo valido");
            }

            if (request.Precio <= 0)
            {
                throw new ExceptionBadRequest("El precio es invalido");

            }

            var clase = new Clase
            {
                DniProfesor = request.DniProfesor,
                Cupo = request.Cupo,
                Precio = request.Precio,
                IdActividad = 1
            };

            var claseProgramada = await _claseCommand.ProgramarClase(clase);

            return new ClaseResponse
            {
                DniProfesor = claseProgramada.DniProfesor,
                Cupo = claseProgramada.Cupo,
                IdClase = claseProgramada.IdClase,
                Precio = claseProgramada.Precio,                
            };

        }

        public async Task<ClaseResponse> ModificarClase(ModificarClaseRequest request) {


            if (request == null)
            {
                throw new ExceptionBadRequest("Debe ingresar datos");
            }

            if (request.Cupo <=  0)
            {
                throw new ExceptionBadRequest("Debe ingresar un cupo valido");
            }

            if (request.Precio <= 0)
            {
                throw new ExceptionBadRequest("El precio es invalido");

            }
                        
            var clase = await _claseQuery.ConsultarClase(request.IdClase);

            if (clase == null)
            {
                throw new ExceptionNotFound("Clase no encontrada");
            }

            clase.DniProfesor = request.DniProfesor;
            clase.Precio = request.Precio;
            clase.Cupo = request.Cupo;
            
            var ClaseModificada = await _claseCommand.ModificarClase(clase);

            return new ClaseResponse
            {
                DniProfesor = ClaseModificada.DniProfesor,
                Precio = ClaseModificada.Precio,
                Cupo = ClaseModificada.Cupo,
                NroActividad=ClaseModificada.IdActividad,
            };
        }

        public async Task<ClaseResponse> ConsultarClase(int claseId) {

            Clase clase = await _claseQuery.ConsultarClase( claseId ) ?? throw new ExceptionNotFound("La clase no existe");

             return new ClaseResponse
            {
                DniProfesor = clase.DniProfesor,
                IdClase = clase.IdClase,
                Cupo = clase.Cupo,
                Precio = clase.Precio,
                NroActividad = clase.IdActividad,
            };
     }     
     
        
        public async Task<ClaseResponse> EliminarClase(int claseId) {


            if (claseId <= 0)
            {
                throw new ExceptionBadRequest("Debe ingresar un id valido");
            }

            var clase = await _claseQuery.ConsultarClase(claseId);

            if (clase == null)
            {
                throw new ExceptionNotFound("Clase no encontrada");
            }

            var claseEliminada = await _claseCommand.EliminarClase(clase);

            return new ClaseResponse
            {
                  IdClase = claseEliminada.IdClase,
                  Cupo = claseEliminada.Cupo,
                  DniProfesor = claseEliminada.DniProfesor,
                  Precio= claseEliminada.Precio
              };


        }
        public async Task<List<InscripcionResponse>> ListarInscripctos() {

            var inscripciones = await _inscripcionQuery.ListaDeInscriptos();


            return inscripciones.Select(inscripcion => new InscripcionResponse
            {                              
                    IdInscripcion = inscripcion.IdInscripcion,
                    DniCliente= inscripcion.DniCliente,
                    Horario= inscripcion.Horario,
                    PrecioInscr = inscripcion.PrecioInscr,
                    NroAct= inscripcion.NroAct,
                    IdAct=inscripcion.IdAct,                    
                    IdDescuento=inscripcion.IdDescuento                            
            }).ToList();
        }
        public async Task<InscripcionResponse> DevolverInscripto(int InscripcionId)
        {

            var inscripcion = await _inscripcionQuery.ConsultarInscripcion(InscripcionId);


            return new InscripcionResponse
            {

                IdInscripcion = inscripcion.IdInscripcion,
                DniCliente = inscripcion.DniCliente,
                Horario = inscripcion.Horario,
                PrecioInscr = inscripcion.PrecioInscr,
                NroAct = inscripcion.NroAct,
                IdAct = inscripcion.IdAct,                
                IdDescuento = inscripcion.IdDescuento
            };



        }
        public async Task<int> ContarCuposLibres(int idActividad, int IdClase)
        {
            // 1. Traer el entrenamiento
            var clase= await _claseQuery.ConsultarClase(IdClase)
                                  ?? throw new ExceptionNotFound("Clase no encontrada");

            // 2. Cupos totales
            int cuposTotales = clase.Cupo;

            // 3. Contar inscriptos (consulta a Inscripción)
            int cuposOcupados = await _inscripcionQuery.ContadorInscripcion(idActividad, IdClase);

            // 4. Restar
            int cuposLibres = cuposTotales - cuposOcupados;

            // 5. Evitar negativos
            return cuposLibres;
        }

        public async Task<AsistenciaResponse> PasarAsistencia(ModificarAsistenciaRequest request)
        {
            var asistencia = await _asistenciaQuery.ConsultarAsistencia(request.IdAsistencia);

            if (asistencia == null)
            {
                throw new ExceptionBadRequest("la Asistencia no existe");
            }
            asistencia.Presente = request.Presente;

            var AsistenciaTomada = await _asistenciaCommand.ModificarAsistencia(asistencia);

            return new AsistenciaResponse
            {
                IdAsistencia = asistencia.IdAsistencia,
                Presente = asistencia.Presente,
                DniCliente = asistencia.DniCliente,
                IdClase = asistencia.IdClase,



            };

        }






















    }
}
