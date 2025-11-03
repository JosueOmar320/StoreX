using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Domain.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Supplier?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Supplier> AddAsync(Supplier supplier, CancellationToken cancellationToken = default);
        Task<Supplier?> UpdateAsync(Supplier supplier, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
