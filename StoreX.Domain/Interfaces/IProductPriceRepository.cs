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
        Task<IEnumerable<ProductPrice>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ProductPrice?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<ProductPrice> AddAsync(ProductPrice productPrice, CancellationToken cancellationToken = default);
        Task<ProductPrice?> UpdateAsync(ProductPrice productPrice, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<ProductPrice>> GetAllPopulateAsync(CancellationToken cancellationToken = default);
    }

}
