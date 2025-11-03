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
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly AppDbContext _context;

        public PurchaseOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PurchaseOrder> AddAsync(PurchaseOrder entity, CancellationToken cancellationToken = default)
        {
            await _context.PurchaseOrders.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<PurchaseOrder?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.PurchaseOrders.FindAsync(id, cancellationToken);
        }

        public async Task<PurchaseOrder?> UpdateAsync(PurchaseOrder entity, CancellationToken cancellationToken = default)
        {
            var existing = await _context.PurchaseOrders.FindAsync(entity.PurchaseOrderId, cancellationToken);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.PurchaseOrders.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.PurchaseOrders.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.PurchaseOrders.ToListAsync(cancellationToken);
        }
    }

}
