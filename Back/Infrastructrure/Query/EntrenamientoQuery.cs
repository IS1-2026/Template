using Application.Interfaces.Entrenamiento;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Query
{
    public class EntrenamientoQuery : IEntrenamientoQuery
    {
        private readonly AppDbContext _context;

        public EntrenamientoQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Entrenamiento> ConsultarEntrenamiento(int EntrenamientoId, CancellationToken ct = default) {
            return await _context.Entrenamientos.FirstOrDefaultAsync(e => e.IdEntrenamiento == EntrenamientoId, ct);
        }
        public async Task<Domain.Entities.Entrenamiento> ImprimirEntrenamiento(int EntrenamientoId, CancellationToken ct = default) {

            return await _context.Entrenamientos.FirstOrDefaultAsync(e => e.IdEntrenamiento == EntrenamientoId ,ct);
        }
        public async Task<int> ContarCuposLibres(int idActividad, int IdEntrenamiento) {

            return  _context.Entrenamientos.Where(e => e.IdEntrenamiento == IdEntrenamiento  &&    e.IdActividad == idActividad).Count();
        }

        public async Task<List<Entrenamiento>> ListarEntrenamientos(CancellationToken ct = default)
        {
            return await _context.Entrenamientos.Include(e=>e.Entrenador).ToListAsync(ct);
        }

        public async Task<List<Entrenamiento>> ListarEntrenamientosPorEntrenador(int entrenadorDni, CancellationToken ct = default)
        {
            return await _context.Entrenamientos.Where(entrenamiento => entrenamiento.DniEntrenador == entrenadorDni).ToListAsync(ct);
        }
    }
}
