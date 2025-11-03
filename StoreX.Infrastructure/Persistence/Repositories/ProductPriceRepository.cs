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
    public class ProductPriceRepository : IProductPriceRepository
    {
        private readonly AppDbContext _context;

        public ProductPriceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductPrice> AddAsync(ProductPrice entity, CancellationToken cancellationToken = default)
        {
            await _context.ProductPrices.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<ProductPrice?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.ProductPrices.FindAsync(id, cancellationToken);
        }

        public async Task<ProductPrice?> UpdateAsync(ProductPrice entity, CancellationToken cancellationToken = default)
        {
            var existing = await _context.ProductPrices.FindAsync(entity.ProductPriceId, cancellationToken);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.ProductPrices.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.ProductPrices.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<ProductPrice>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ProductPrices.ToListAsync(cancellationToken);
        }
    }
}
