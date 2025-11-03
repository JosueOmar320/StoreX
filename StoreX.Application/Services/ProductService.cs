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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
            => _productRepository.AddAsync(product, cancellationToken);

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
            => _productRepository.DeleteAsync(id, cancellationToken);

        public Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
            => _productRepository.GetAllAsync(cancellationToken);

        public Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _productRepository.GetByIdAsync(id, cancellationToken);

        public Task<Product?> UpdateAsync(Product product, CancellationToken cancellationToken = default)
            => _productRepository.UpdateAsync(product, cancellationToken);
    }
}
