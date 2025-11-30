using StoreX.Application.Dtos;
using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default);
        Task<Product?> UpdateAsync(Product product, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<ProductDto>> GetAllPopulateAsync(CancellationToken cancellationToken = default);
    }
}
