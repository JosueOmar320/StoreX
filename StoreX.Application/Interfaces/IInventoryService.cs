using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Inventory?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Inventory> AddAsync(Inventory inventory, CancellationToken cancellationToken = default);
        Task<Inventory?> UpdateAsync(Inventory inventory, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
