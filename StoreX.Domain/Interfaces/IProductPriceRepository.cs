using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreX.Domain.Entities;


namespace StoreX.Domain.Interfaces
{
    public interface IProductPriceRepository
    {
        Task<IEnumerable<ProductPrice>> GetAllAsync();
        Task<ProductPrice> GetByIdAsync(int id);
        Task<ProductPrice> AddAsync(ProductPrice productPrice);
        Task<ProductPrice> UpdateAsync(ProductPrice productPrice);
        Task<bool> DeleteAsync(int id);
    }

}
