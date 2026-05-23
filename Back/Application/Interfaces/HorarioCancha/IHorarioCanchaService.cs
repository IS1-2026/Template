
using Application.DTOs.Request.HorarioCancha;
using Application.UseCases;
using Domain.Entities;

namespace Application.Interfaces.HorarioCancha
{
    public interface IHorarioCanchaService
    {
        Task CrearHorario(int CanchaId,CrearHorarioCanchaRequest request);
    }
}
