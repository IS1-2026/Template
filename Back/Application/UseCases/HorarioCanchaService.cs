
using Application.DTOs.Request.HorarioCancha;
using Application.Exceptions;
using Application.Interfaces.HorarioCancha;

namespace Application.UseCases
{
    public class HorarioCanchaService : IHorarioCanchaService
    {
       public async Task CrearHorario(int CanchaId, CrearHorarioCanchaRequest request)
        {
            if(CanchaId<=0 || CanchaId == null) 
            {
                throw new ExceptionBadRequest("Ingrese una cancha valida");
            }

            if (request.HoraInicio > request.HoraFin) 
            {
                throw new ExceptionBadRequest("Ingrese un rango horario valido");
            }


        }
    }
}
