using Application.Interfaces.Cobro;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class CobroQuery : ICobroQuery
    {
        private readonly AppDbContext _context;

        public CobroQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cobro> ConsultarCobro(int idCobro, CancellationToken ct = default)
        {
            // Buscamos por IdCobro usando FirstOrDefaultAsync igual que en Entrenamiento
            return await _context.Cobros.FirstOrDefaultAsync(c => c.IdCobro == idCobro, ct);
        }
    }
}
