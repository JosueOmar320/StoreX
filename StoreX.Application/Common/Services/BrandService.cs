using StoreX.Application.Common.Interfaces;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Common.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<Brand> AddAsync(Brand brand)
        {
            return await _brandRepository.AddAsync(brand);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await _brandRepository.GetAllAsync();
        }

        public Task<Brand> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Brand> UpdateAsync(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
