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

        public async Task<Movement> AddAsync(Movement movement)
        {
            await _context.Movements.AddAsync(movement);
            await _context.SaveChangesAsync();
            return movement;
        }

        public async Task<Movement> GetByIdAsync(int id)
        {
            return await _context.Movements.FindAsync(id);
        }

        public async Task<Movement> UpdateAsync(Movement movement)
        {
            var existing = await _context.Movements.FindAsync(movement.MovementId);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(movement);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Movements.FindAsync(id);
            if (entity == null)
                return false;

            _context.Movements.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Movement>> GetAllAsync()
        {
            return await _context.Movements.ToListAsync();
        }
    }
}
