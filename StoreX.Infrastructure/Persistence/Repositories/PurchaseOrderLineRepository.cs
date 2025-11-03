using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;

namespace StoreX.Infrastructure.Persistence.Repositories
{
    public class PurchaseOrderLineRepository : IPurchaseOrderLineRepository
    {
        private readonly AppDbContext _context;

        public PurchaseOrderLineRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PurchaseOrderLine> AddAsync(PurchaseOrderLine entity, CancellationToken cancellationToken = default)
        {
            await _context.PurchaseOrderLines.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<PurchaseOrderLine?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.PurchaseOrderLines.FindAsync(id, cancellationToken);
        }

        public async Task<PurchaseOrderLine?> UpdateAsync(PurchaseOrderLine entity, CancellationToken cancellationToken = default)
        {
            var existing = await _context.PurchaseOrderLines.FindAsync(entity.PurchaseOrderLineId, cancellationToken);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.PurchaseOrderLines.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.PurchaseOrderLines.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<PurchaseOrderLine>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.PurchaseOrderLines.ToListAsync(cancellationToken);
        }
    }
}
