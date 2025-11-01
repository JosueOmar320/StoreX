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

        public async Task<MovementLine> AddAsync(MovementLine entity)
        {
            await _context.MovementLines.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<MovementLine> GetByIdAsync(int id)
        {
            return await _context.MovementLines.FindAsync(id);
        }

        public async Task<MovementLine> UpdateAsync(MovementLine entity)
        {
            var existing = await _context.MovementLines.FindAsync(entity.MovementLineId);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.MovementLines.FindAsync(id);
            if (entity == null)
                return false;

            _context.MovementLines.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<MovementLine>> GetAllAsync()
        {
            return await _context.MovementLines.ToListAsync();
        }
    }
}
