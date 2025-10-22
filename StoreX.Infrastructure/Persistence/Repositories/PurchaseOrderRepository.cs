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

        public async Task<PurchaseOrder> AddAsync(PurchaseOrder purchaseOrder)
        {
            await _context.PurchaseOrders.AddAsync(purchaseOrder);
            await _context.SaveChangesAsync();
            return purchaseOrder;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAllAsync()
        {
            return await _context.PurchaseOrders.ToListAsync();
        }

        public Task<PurchaseOrder> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PurchaseOrder> UpdateAsync(PurchaseOrder purchaseOrder)
        {
            throw new NotImplementedException();
        }
    }

}
