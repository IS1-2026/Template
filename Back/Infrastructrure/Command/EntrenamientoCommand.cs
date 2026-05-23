using Application.Interfaces.Entrenamiento;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class EntrenamientoCommand : IEntrenamientoCommand
    {
        private readonly AppDbContext _context;

        public EntrenamientoCommand(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Domain.Entities.Entrenamiento> ProgramarEntrenamiento(Domain.Entities.Entrenamiento Entrenamiento, CancellationToken ct = default)
        {
            await _context.Entrenamientos.AddAsync(Entrenamiento, ct);
            await _context.SaveChangesAsync(ct);
            return Entrenamiento;
        }
        public async Task<Domain.Entities.Entrenamiento> ModificarEntrenamiento(Domain.Entities.Entrenamiento Entrenamiento, CancellationToken ct = default)
        {

            _context.Entrenamientos.Update(Entrenamiento); 
            await _context.SaveChangesAsync(ct);
            return Entrenamiento;
        }
        public async Task<Domain.Entities.Entrenamiento> EliminarEntrenamiento(Domain.Entities.Entrenamiento Entrenamiento, CancellationToken ct = default)
        {
            _context.Remove(Entrenamiento);
            await _context.SaveChangesAsync(ct);
            return Entrenamiento;
        }


    }
}
