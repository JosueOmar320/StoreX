using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Interfaces
{
    public interface IProductPriceService
    {
        Task<IEnumerable<ProductPrice>> GetAllAsync();
        Task<ProductPrice> GetByIdAsync(int id);
        Task<ProductPrice> AddAsync(ProductPrice productPrice);
        Task<ProductPrice> UpdateAsync(ProductPrice productPrice);
        Task<bool> DeleteAsync(int id);
    }
}
