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

        public async Task<ProductPrice> AddAsync(ProductPrice productPrice)
        {
            await _context.ProductPrices.AddAsync(productPrice);
            await _context.SaveChangesAsync();
            return productPrice;
        }

        public async Task<ProductPrice> GetByIdAsync(int id)
        {
            var existingProductPrice = await _context.ProductPrices.FindAsync(id);
            if (existingProductPrice == null)
                return null;

            return existingProductPrice;
        }

        public async Task<ProductPrice> UpdateAsync(ProductPrice productPrice)
        {
            var existingProductPrice = await _context.ProductPrices.FindAsync(productPrice.ProductPriceId);
            if (existingProductPrice == null)
                return null;

            _context.Entry(existingProductPrice).CurrentValues.SetValues(productPrice);
            await _context.SaveChangesAsync();
            return existingProductPrice;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var productPrice = await _context.ProductPrices.FindAsync(id);
            if (productPrice == null)
                return false;

            _context.ProductPrices.Remove(productPrice);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductPrice>> GetAllAsync()
        {
            return await _context.ProductPrices.ToListAsync();
        }
    }
}
