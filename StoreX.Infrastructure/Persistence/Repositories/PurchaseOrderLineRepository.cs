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

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PurchaseOrderLine>> GetAllAsync()
        {
            return await _context.PurchaseOrderLines.ToListAsync();
        }

        public Task<PurchaseOrderLine> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PurchaseOrderLine> UpdateAsync(PurchaseOrderLine purchaseOrderLine)
        {
            throw new NotImplementedException();
        }
    }
}
