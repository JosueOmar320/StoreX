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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _repo;

        public ProductCategoryService(IProductCategoryRepository repo)
        {
            _repo = repo;
        }

        public Task<ProductCategory> AddAsync(ProductCategory entity, CancellationToken token = default)
            => _repo.AddAsync(entity, token);

        public Task<bool> DeleteAsync(int id, CancellationToken token = default)
            => _repo.DeleteAsync(id, token);

        public Task<IEnumerable<ProductCategory>> GetAllAsync(CancellationToken token = default)
            => _repo.GetAllAsync(token);

        public Task<ProductCategory?> GetByIdAsync(int id, CancellationToken token = default)
            => _repo.GetByIdAsync(id, token);

        public Task<ProductCategory?> UpdateAsync(ProductCategory entity, CancellationToken token = default)
            => _repo.UpdateAsync(entity, token);
    }
}
