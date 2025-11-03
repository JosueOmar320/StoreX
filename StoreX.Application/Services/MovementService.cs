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
    public class MovementService : IMovementService
    {
        private readonly IMovementRepository _repo;

        public MovementService(IMovementRepository repo)
        {
            _repo = repo;
        }

        public Task<Movement> AddAsync(Movement entity, CancellationToken token = default)
            => _repo.AddAsync(entity, token);

        public Task<bool> DeleteAsync(int id, CancellationToken token = default)
            => _repo.DeleteAsync(id, token);

        public Task<IEnumerable<Movement>> GetAllAsync(CancellationToken token = default)
            => _repo.GetAllAsync(token);

        public Task<Movement?> GetByIdAsync(int id, CancellationToken token = default)
            => _repo.GetByIdAsync(id, token);

        public Task<Movement?> UpdateAsync(Movement entity, CancellationToken token = default)
            => _repo.UpdateAsync(entity, token);
    }
}
