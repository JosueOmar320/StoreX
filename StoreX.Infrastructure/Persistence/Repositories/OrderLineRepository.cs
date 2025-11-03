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
    public class OrderLineRepository : IOrderLineRepository
    {
        private readonly AppDbContext _context;

        public OrderLineRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrderLine> AddAsync(OrderLine entity, CancellationToken cancellationToken = default)
        {
            await _context.OrderLines.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<OrderLine?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.OrderLines.FindAsync(id, cancellationToken);
        }

        public async Task<OrderLine?> UpdateAsync(OrderLine entity, CancellationToken cancellationToken = default)
        {
            var existing = await _context.OrderLines.FindAsync(entity.OrderLineId, cancellationToken);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.OrderLines.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.OrderLines.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<OrderLine>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.OrderLines.ToListAsync(cancellationToken);
        }
    }
}
