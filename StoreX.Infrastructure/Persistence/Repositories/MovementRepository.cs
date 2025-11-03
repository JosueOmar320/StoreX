using Microsoft.EntityFrameworkCore;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Infrastructure.Persistence.Repositories
{
    public class MovementRepository : IMovementRepository
    {
        private readonly AppDbContext _context;

        public MovementRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Movement> AddAsync(Movement movement, CancellationToken cancellationToken = default)
        {
            await _context.Movements.AddAsync(movement, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return movement;
        }

        public async Task<Movement?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Movements.FindAsync(id, cancellationToken);
        }

        public async Task<Movement?> UpdateAsync(Movement movement, CancellationToken cancellationToken = default)
        {
            var existing = await _context.Movements.FindAsync(movement.MovementId, cancellationToken);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(movement);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Movements.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.Movements.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Movement>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Movements.ToListAsync(cancellationToken);
        }
    }
}
