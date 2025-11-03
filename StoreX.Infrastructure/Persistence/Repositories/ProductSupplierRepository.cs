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

        public async Task<ProductSupplier> AddAsync(ProductSupplier entity, CancellationToken cancellationToken = default)
        {
            await _context.ProductSuppliers.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<ProductSupplier?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.ProductSuppliers.FindAsync(id, cancellationToken);
        }

        public async Task<ProductSupplier?> UpdateAsync(ProductSupplier entity, CancellationToken cancellationToken = default)
        {
            var existing = await _context.ProductSuppliers.FindAsync(entity.ProductSupplierId, cancellationToken);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.ProductSuppliers.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.ProductSuppliers.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<ProductSupplier>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ProductSuppliers.ToListAsync(cancellationToken);
        }
    }

}
