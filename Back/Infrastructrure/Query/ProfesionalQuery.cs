using Application.Interfaces.Profesionales;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Query
{
    public class ProfesionalQuery : IProfesionalQuery
    {
        private readonly AppDbContext context;

        public ProfesionalQuery(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Profesor> ObtenerProfesorPorId(int id)
        {
            return await context.Set<Profesor>()
                .Include(p => p.Clases)
                .FirstOrDefaultAsync(p => p.Dni == id);
        }

        public async Task<Entrenador> ObtenerEntrenadorPorId(int id)
        {
            return await context.Set<Entrenador>()
                .Include(e => e.Entrenamientos)
                .FirstOrDefaultAsync(e => e.Dni == id);
        }

        public async Task<List<Profesor>> ObtenerTodosLosProfesores()
        {
            return await context.Set<Profesor>()
                .Include(p => p.Clases)
                .ToListAsync();
        }

        public async Task<List<Entrenador>> ObtenerTodosLosEntrenadores()
        {
            return await context.Set<Entrenador>()
                .Include(e => e.Entrenamientos)
                .ToListAsync();
        }

        public async Task<Profesor> ProfesorLogin(string correo, CancellationToken ct = default)
        {
            return await context.Set<Profesor>().FirstOrDefaultAsync(p => p.Correo == correo, ct);
        }

        public async Task<Entrenador> EntrenadorLogin(string correo, CancellationToken ct = default)
        {
            return await context.Set<Entrenador>().FirstOrDefaultAsync(p => p.Correo == correo, ct);
        }
    }
}
