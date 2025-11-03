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
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductCategory> AddAsync(ProductCategory entity, CancellationToken cancellationToken = default)
        {
            await _context.ProductCategories.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<ProductCategory?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.ProductCategories.FindAsync(id, cancellationToken);
        }

        public async Task<ProductCategory?> UpdateAsync(ProductCategory entity, CancellationToken cancellationToken = default)
        {
            var existing = await _context.ProductCategories
                .FirstOrDefaultAsync(pc => pc.ProductId == entity.ProductId && pc.CategoryId == entity.CategoryId, cancellationToken);
            if (existing == null)
                return null;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.ProductCategories.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.ProductCategories.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<ProductCategory>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ProductCategories.ToListAsync(cancellationToken);
        }
    }
}
