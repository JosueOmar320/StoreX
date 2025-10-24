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

        public async Task<OrderLine> AddAsync(OrderLine orderLine)
        {
            await _context.OrderLines.AddAsync(orderLine);
            await _context.SaveChangesAsync();
            return orderLine;
        }

        public async Task<OrderLine> GetByIdAsync(int id)
        {
            var existingOrderLine = await _context.OrderLines.FindAsync(id);
            if (existingOrderLine == null)
                return null;

            return existingOrderLine;
        }

        public async Task<OrderLine> UpdateAsync(OrderLine orderLine)
        {
            var existingOrderLine = await _context.OrderLines.FindAsync(orderLine.OrderLineId);
            if (existingOrderLine == null)
                return null;

            _context.Entry(existingOrderLine).CurrentValues.SetValues(orderLine);
            await _context.SaveChangesAsync();
            return existingOrderLine;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var orderLine = await _context.OrderLines.FindAsync(id);
            if (orderLine == null)
                return false;

            _context.OrderLines.Remove(orderLine);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<OrderLine>> GetAllAsync()
        {
            return await _context.OrderLines.ToListAsync();
        }
    }
}
