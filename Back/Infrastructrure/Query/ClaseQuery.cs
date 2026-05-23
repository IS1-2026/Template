using Application.Interfaces.Clase;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Query
{
    public class ClaseQuery : IClaseQuery
    {

        private readonly AppDbContext _context;

        public ClaseQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.Entities.Clase> ConsultarClase(int Clase, CancellationToken ct = default) {

            return  _context.Clases.FirstOrDefault(c => c.IdClase == Clase);
        }
        public async Task<List<Domain.Entities.Clase>> MostrarInscriptos(CancellationToken ct = default) {

            return await  _context.Clases.ToListAsync(ct);
        }

        public async Task<Domain.Entities.Inscripcion> DevolverInscripto(int InscripcionId, CancellationToken ct = default) {
            return _context.Inscripciones.FirstOrDefault(i => i.IdInscripcion == InscripcionId);
        }


        

        
    }
}
