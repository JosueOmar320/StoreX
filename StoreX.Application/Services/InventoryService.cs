using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _repo;

        public InventoryService(IInventoryRepository repo)
        {
            _repo = repo;
        }

        public Task<Inventory> AddAsync(Inventory entity, CancellationToken token = default)
            => _repo.AddAsync(entity, token);

        public Task<bool> DeleteAsync(int id, CancellationToken token = default)
            => _repo.DeleteAsync(id, token);

        public Task<IEnumerable<Inventory>> GetAllAsync(CancellationToken token = default)
            => _repo.GetAllAsync(token);

        public Task<Inventory> GetByIdAsync(int id, CancellationToken token = default)
            => _repo.GetByIdAsync(id, token);

        public Task<Inventory> UpdateAsync(Inventory entity, CancellationToken token = default)
            => _repo.UpdateAsync(entity, token);
    }
}
