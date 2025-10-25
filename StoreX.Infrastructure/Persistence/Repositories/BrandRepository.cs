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
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _context;

        public BrandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Brand> AddAsync(Brand brand)
        {
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            var existingBrand = await _context.Brands.FindAsync(id);
            if (existingBrand == null)
                return null;

            return existingBrand;
        }

        public async Task<Brand> UpdateAsync(Brand brand)
        {
            var existingBrand = await _context.Brands.FindAsync(brand.BrandId);
            if (existingBrand == null)
                return null;

            _context.Entry(existingBrand).CurrentValues.SetValues(brand);
            await _context.SaveChangesAsync();
            return existingBrand;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null) 
                return false;

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await _context.Brands.ToListAsync();
        }
    }
}
