using Application.DTOs.Request.Asistencia;
using Application.DTOs.Response.Asistencia;
using Application.Exceptions;
using Application.Interfaces.Asistencia;
using Domain.Entities;


namespace Application.UseCases
{
    public  class AsistenciaService : IAsistenciaService
    {
        private readonly IAsistenciaCommand _asistenciaCommand;
        private readonly IAsistenciaQuery _asistenciaQuery;
       

        public AsistenciaService(
            IAsistenciaCommand asistenciaCommand,
            IAsistenciaQuery asistenciaQuery
            )
        {
            _asistenciaCommand = asistenciaCommand;
            _asistenciaQuery = asistenciaQuery;
          
        }

        public async Task<AsistenciaResponse> RegistrarAsistencia(int claseId,RegistrarAsistenciaRequest request)
        {
            var asistencia = new Asistencia
            {
                IdClase=claseId,
                DniCliente = request.DniCliente,
                Presente = request.Presente
            };

            var claseCreada = await _asistenciaCommand.RegistrarAsistencia(asistencia);

            return new AsistenciaResponse
            {
                IdAsistencia = claseCreada.IdAsistencia,
                DniCliente = claseCreada.DniCliente,
                IdClase = claseCreada.IdClase,
                Presente = claseCreada.Presente
            };
        }

        public async Task<AsistenciaResponse> ModificarAsistencia(ModificarAsistenciaRequest request) {

        
            var asistencia = await _asistenciaQuery.ConsultarAsistencia(request.IdAsistencia);
            

            asistencia.Presente = request.Presente;
            asistencia.DniCliente= request.DniCliente;
            asistencia.IdClase= request.IdClase;
           

            var asistenciaActualizada = await _asistenciaCommand.ModificarAsistencia (asistencia);

            return new AsistenciaResponse
            {
                Presente = asistenciaActualizada.Presente,
                DniCliente = asistenciaActualizada.DniCliente,
                IdClase = asistenciaActualizada.IdClase
            };
        }

        public async Task<AsistenciaResponse> EliminarAsitencia(int IdAsistencia) {

            var asistencia = await _asistenciaQuery.ConsultarAsistencia(IdAsistencia);

            var asistenciaEliminada = await _asistenciaCommand.EliminarAsistencia(asistencia);

            return new AsistenciaResponse
            {
                Presente = asistencia.Presente,
                DniCliente = asistencia.DniCliente,
                IdClase = asistencia.IdClase,
            };


        }

        public async Task<AsistenciaResponse> ConsultarAsistencia(int IdAsistencia) {

            var asistencia = await _asistenciaQuery.ConsultarAsistencia(IdAsistencia);


            return new AsistenciaResponse
            {
                Presente = asistencia.Presente,
                DniCliente = asistencia.DniCliente,
                IdClase = asistencia.IdClase,
            };

        }

        public async Task<List<AsistenciaResponse>> ListarAsistencia(int idClase)
        {
            var asistencias = await _asistenciaQuery.ListarAsistencia(idClase);

            return asistencias
                .Where(a => a.IdClase == idClase) 
                .Select(r => new AsistenciaResponse
                {
                    IdAsistencia = r.IdAsistencia,
                    DniCliente = r.DniCliente,
                    IdClase = r.IdClase,
                    Presente = r.Presente
                }).ToList();
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
