using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository) 
        {
            _brandRepository = brandRepository;
        }

        public Task<Brand> AddAsync(Brand brand, CancellationToken cancellationToken = default)
            => _brandRepository.AddAsync(brand, cancellationToken);

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
            => _brandRepository.DeleteAsync(id, cancellationToken);

        public Task<IEnumerable<Brand>> GetAllAsync(CancellationToken cancellationToken = default)
            => _brandRepository.GetAllAsync(cancellationToken);

        public Task<Brand?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _brandRepository.GetByIdAsync(id, cancellationToken);

        public Task<Brand?> UpdateAsync(Brand brand, CancellationToken cancellationToken = default)
            => _brandRepository.UpdateAsync(brand, cancellationToken);
    }
}
