using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Domain.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetAllAsync();
        Task<ProductCategory> GetByIdAsync(int id);
        Task<ProductCategory> AddAsync(ProductCategory productCategory);
        Task<ProductCategory> UpdateAsync(ProductCategory productCategory);
        Task<bool> DeleteAsync(int id);
    }
}
