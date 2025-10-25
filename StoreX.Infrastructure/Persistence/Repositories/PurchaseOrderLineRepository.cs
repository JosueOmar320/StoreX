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

        public async Task<PurchaseOrderLine> AddAsync(PurchaseOrderLine purchaseOrderLine)
        {
            await _context.PurchaseOrderLines.AddAsync(purchaseOrderLine);
            await _context.SaveChangesAsync();
            return purchaseOrderLine;
        }

        public async Task<PurchaseOrderLine> GetByIdAsync(int id)
        {
            var existingLine = await _context.PurchaseOrderLines.FindAsync(id);
            if (existingLine == null)
                return null;

            return existingLine;
        }

        public async Task<PurchaseOrderLine> UpdateAsync(PurchaseOrderLine purchaseOrderLine)
        {
            var existingLine = await _context.PurchaseOrderLines.FindAsync(purchaseOrderLine.PurchaseOrderLineId);
            if (existingLine == null)
                return null;

            _context.Entry(existingLine).CurrentValues.SetValues(purchaseOrderLine);
            await _context.SaveChangesAsync();
            return existingLine;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var line = await _context.PurchaseOrderLines.FindAsync(id);
            if (line == null)
                return false;

            _context.PurchaseOrderLines.Remove(line);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PurchaseOrderLine>> GetAllAsync()
        {
            return await _context.PurchaseOrderLines.ToListAsync();
        }
    }
}
