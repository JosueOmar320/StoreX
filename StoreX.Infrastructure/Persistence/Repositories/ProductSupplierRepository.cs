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
    public class ProductSupplierRepository : IProductSupplierRepository
    {
        private readonly AppDbContext _context;

        public ProductSupplierRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductSupplier> AddAsync(ProductSupplier entity)
        {
            await _context.ProductSuppliers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ProductSupplier> GetByIdAsync(int id)
        {
            return await _context.ProductSuppliers.FindAsync(id);
        }

        public async Task<ProductSupplier> UpdateAsync(ProductSupplier entity)
        {
            var existing = await _context.ProductSuppliers.FindAsync(entity.ProductSupplierId);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ProductSuppliers.FindAsync(id);
            if (entity == null)
                return false;

            _context.ProductSuppliers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductSupplier>> GetAllAsync()
        {
            return await _context.ProductSuppliers.ToListAsync();
        }
    }

}
