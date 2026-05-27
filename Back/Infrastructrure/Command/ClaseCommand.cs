using Application.Interfaces.Clase;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Command
{
    public  class ClaseCommand : IClaseCommand
    {
        private readonly AppDbContext _context;

        public ClaseCommand(AppDbContext context)
        {
            _context = context;
        }



        public async Task<Domain.Entities.Clase> ProgramarClase(Domain.Entities.Clase Clase, CancellationToken ct = default) {


            await _context.Clases.AddAsync(Clase, ct);
            await _context.SaveChangesAsync(ct);
            return Clase;
        }
        public async Task<Domain.Entities.Clase> ModificarClase(Domain.Entities.Clase Clase, CancellationToken ct = default) {


            _context.Clases.Update(Clase);
            await _context.SaveChangesAsync(ct);
            return Clase;
        }
        public async Task<Domain.Entities.Clase> EliminarClase(Domain.Entities.Clase Clase, CancellationToken ct = default) {
            _context.Remove(Clase);
            await _context.SaveChangesAsync(ct);
            return Clase;
        }
        public async Task<Domain.Entities.Asistencia> PasarAsistencia(Domain.Entities.Asistencia Asistencia, CancellationToken ct = default) {

            _context.Asistencias.Update(Asistencia);
            await _context.SaveChangesAsync(ct);
            return Asistencia;

        }

        public Task<Asistencia> PasarAsistencia(Clase Clase, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DecrementarCupo(int claseId, CancellationToken ct = default)
        {
            var clase = await _context.Clases.FirstOrDefaultAsync(c => c.IdClase == claseId, ct);
            clase.Cupo--;
            await _context.SaveChangesAsync(ct);
            return clase.Cupo;
        }
    }
}
