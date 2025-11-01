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

        public async Task<ProductCategory> AddAsync(ProductCategory entity)
        {
            await _context.ProductCategories.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ProductCategory> GetByIdAsync(int id)
        {
            return await _context.ProductCategories.FindAsync(id);
        }

        //public async Task<ProductCategory> UpdateAsync(ProductCategory entity)
        //{
        //    var existing = await _context.ProductCategories.FindAsync(entity.ProductCategoryId);
        //    if (existing == null)
        //        return null;

        //    _context.Entry(existing).CurrentValues.SetValues(entity);
        //    await _context.SaveChangesAsync();
        //    return existing;
        //}

        public Task<ProductCategory> UpdateAsync(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ProductCategories.FindAsync(id);
            if (entity == null)
                return false;

            _context.ProductCategories.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }
    }
}
