using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Interfaces
{
    public interface IProductSupplierService
    {
        Task<IEnumerable<ProductSupplier>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ProductSupplier?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<ProductSupplier> AddAsync(ProductSupplier productSupplier, CancellationToken cancellationToken = default);
        Task<ProductSupplier?> UpdateAsync(ProductSupplier productSupplier, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
