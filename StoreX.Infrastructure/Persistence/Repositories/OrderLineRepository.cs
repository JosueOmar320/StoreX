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

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderLine>> GetAllAsync()
        {
            return await _context.OrderLines.ToListAsync();
        }

        public Task<OrderLine> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderLine> UpdateAsync(OrderLine orderLine)
        {
            throw new NotImplementedException();
        }
    }
}
