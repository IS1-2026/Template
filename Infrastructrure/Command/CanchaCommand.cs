
using Application.Interfaces.Commands;
using Domain.Entities;
using Infrastructrure.Persistence;

namespace Infrastructrure.Command
{
    public class CanchaCommand : ICanchaCommand
    {
        private readonly AppDbContext _context;

        public CanchaCommand(AppDbContext context)
        {
            _context = context;
        }

        public Task<Cancha> CrearCancha(Cancha cancha, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
