
using Application.Interfaces.HorarioCancha;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class HorarioCanchaCommand : IHorarioCanchaCommand
    {
        private readonly AppDbContext _context;

        public HorarioCanchaCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HorarioCancha> CrearHorario(HorarioCancha horarioCancha, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<HorarioCancha> ModificarHorario(HorarioCancha horarioCancha, CancellationToken ct = default)
        {
            _context.HorarioCancha.Update(horarioCancha);
            await _context.SaveChangesAsync();
            return horarioCancha;
        }
    }
}
