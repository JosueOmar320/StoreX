using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreX.Application.Dtos;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;

namespace StoreX.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var existingProduct = await _context.Products.FindAsync(id, cancellationToken);
            if (existingProduct == null)
                return null;

            return existingProduct;
        }

        public async Task<Product?> UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            var existingProduct = await _context.Products.FindAsync(product.ProductId, cancellationToken);
            if (existingProduct == null)
                return null;

            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync(cancellationToken);
            return existingProduct;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var product = await _context.Products.FindAsync(id, cancellationToken);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllPopulateAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Products.Include(x => x.Brand).ToListAsync(cancellationToken);
        }

    }
}
