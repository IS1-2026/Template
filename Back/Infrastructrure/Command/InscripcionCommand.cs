
using Application.Interfaces.Incripcion;
using Domain.Entities;
using Infrastructure.Persistence;


namespace Infrastructure.Command
{
    public  class InscripcionCommand : IInscripcionCommand
    {
        private readonly AppDbContext _context;

        public InscripcionCommand(AppDbContext context)
        {
            _context = context;
        }




        public async Task<Inscripcion> AgregarInscripcion(Domain.Entities.Inscripcion Inscricion, CancellationToken ct = default) {

            await _context.AddAsync(Inscricion, ct);
            await _context.SaveChangesAsync(ct);
            return Inscricion;

        }


        public async Task<Inscripcion> EliminarInscripcion(Domain.Entities.Inscripcion Inscricion, CancellationToken ct = default) {

            _context.Remove(Inscricion); 
            await _context.SaveChangesAsync(ct); 
            return Inscricion;

        }

    }
}
