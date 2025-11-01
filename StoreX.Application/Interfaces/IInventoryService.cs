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
        Task<IEnumerable<Inventory>> GetAllAsync();
        Task<Inventory> GetByIdAsync(int id);
        Task<Inventory> AddAsync(Inventory inventory);
        Task<Inventory> UpdateAsync(Inventory inventory);
        Task<bool> DeleteAsync(int id);
    }
}
