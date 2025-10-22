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

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductPrice>> GetAllAsync()
        {
            return await _context.ProductPrices.ToListAsync();
        }

        public Task<ProductPrice> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductPrice> UpdateAsync(ProductPrice productPrice)
        {
            throw new NotImplementedException();
        }
    }

}
