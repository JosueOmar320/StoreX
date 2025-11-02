using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Interfaces
{
   public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ProductCategory?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<ProductCategory> AddAsync(ProductCategory productCategory, CancellationToken cancellationToken = default);
        Task<ProductCategory?> UpdateAsync(ProductCategory productCategory, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
