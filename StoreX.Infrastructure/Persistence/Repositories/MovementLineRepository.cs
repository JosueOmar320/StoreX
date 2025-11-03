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
    public class MovementLineRepository : IMovementLineRepository
    {
        private readonly AppDbContext _context;

        public MovementLineRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MovementLine> AddAsync(MovementLine entity, CancellationToken cancellationToken = default)
        {
            await _context.MovementLines.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<MovementLine?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.MovementLines.FindAsync(id, cancellationToken);
        }

        public async Task<MovementLine?> UpdateAsync(MovementLine entity, CancellationToken cancellationToken = default)
        {
            var existing = await _context.MovementLines.FindAsync(entity.MovementLineId, cancellationToken);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.MovementLines.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.MovementLines.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<MovementLine>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.MovementLines.ToListAsync(cancellationToken);
        }
    }
}
