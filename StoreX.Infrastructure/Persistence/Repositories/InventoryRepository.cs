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
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDbContext _context;

        public InventoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Inventory> AddAsync(Inventory entity, CancellationToken cancellationToken = default)
        {
            await _context.Inventories.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<Inventory?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Inventories.FindAsync(id, cancellationToken);
        }

        public async Task<Inventory?> UpdateAsync(Inventory entity, CancellationToken cancellationToken = default)
        {
            var existing = await _context.Inventories.FindAsync(entity.InventoryId, cancellationToken);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Inventories.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.Inventories.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Inventory>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Inventories.ToListAsync(cancellationToken);
        }
    }
}
