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
        Task<IEnumerable<ProductSupplier>> GetAllAsync();
        Task<ProductSupplier> GetByIdAsync(int id);
        Task<ProductSupplier> AddAsync(ProductSupplier productSupplier);
        Task<ProductSupplier> UpdateAsync(ProductSupplier productSupplier);
        Task<bool> DeleteAsync(int id);
    }
}
