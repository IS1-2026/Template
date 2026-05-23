using Application.Interfaces.Asistencia;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Query
{
    public  class AsistenciaQuery : IAsistenciaQuery
    {
        private readonly AppDbContext _context;

        public AsistenciaQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Asistencia> ConsultarAsistencia(int idAsistencia) {
            return await _context.Asistencias.FirstOrDefaultAsync(e => e.IdAsistencia == idAsistencia);
        }

        public async Task<List<Domain.Entities.Asistencia>> ListarAsistencia(int idClase) {
            return await _context.Asistencias.Where(a => a.IdClase == idClase).ToListAsync();
        }

        public async Task<List<Domain.Entities.Asistencia>> ConsultarAsistenciaporDNI(int DniCliente) {
            return await _context.Asistencias.Where(a => a.DniCliente == DniCliente).ToListAsync();
        }
    }
}
