using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreX.Application.Services
{
    public class ProductPriceService : IProductPriceService
    {
        private readonly IProductPriceRepository _productPriceRepository;

        public ProductPriceService(IProductPriceRepository productPriceRepository)
        {
            _productPriceRepository = productPriceRepository;
        }

        public Task<ProductPrice> AddAsync(ProductPrice productPrice, CancellationToken cancellationToken = default)
            => _productPriceRepository.AddAsync(productPrice, cancellationToken);

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
            => _productPriceRepository.DeleteAsync(id, cancellationToken);

        public Task<IEnumerable<ProductPrice>> GetAllAsync(CancellationToken cancellationToken = default)
            => _productPriceRepository.GetAllAsync(cancellationToken);

        public Task<ProductPrice?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _productPriceRepository.GetByIdAsync(id, cancellationToken);

        public Task<ProductPrice?> UpdateAsync(ProductPrice productPrice, CancellationToken cancellationToken = default)
            => _productPriceRepository.UpdateAsync(productPrice, cancellationToken);
    }
}
