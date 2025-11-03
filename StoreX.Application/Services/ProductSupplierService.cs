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
    public class ProductSupplierService : IProductSupplierService
    {
        private readonly IProductSupplierRepository _repo;

        public ProductSupplierService(IProductSupplierRepository repo)
        {
            _repo = repo;
        }

        public Task<ProductSupplier> AddAsync(ProductSupplier entity, CancellationToken token = default)
            => _repo.AddAsync(entity, token);

        public Task<bool> DeleteAsync(int id, CancellationToken token = default)
            => _repo.DeleteAsync(id, token);

        public Task<IEnumerable<ProductSupplier>> GetAllAsync(CancellationToken token = default)
            => _repo.GetAllAsync(token);

        public Task<ProductSupplier?> GetByIdAsync(int id, CancellationToken token = default)
            => _repo.GetByIdAsync(id, token);

        public Task<ProductSupplier?> UpdateAsync(ProductSupplier entity, CancellationToken token = default)
            => _repo.UpdateAsync(entity, token);
    }
}
