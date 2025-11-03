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
    public class MovementLineService : IMovementLineService
    {
        private readonly IMovementLineRepository _repo;

        public MovementLineService(IMovementLineRepository repo)
        {
            _repo = repo;
        }

        public Task<MovementLine> AddAsync(MovementLine entity, CancellationToken token = default)
            => _repo.AddAsync(entity, token);

        public Task<bool> DeleteAsync(int id, CancellationToken token = default)
            => _repo.DeleteAsync(id, token);

        public Task<IEnumerable<MovementLine>> GetAllAsync(CancellationToken token = default)
            => _repo.GetAllAsync(token);

        public Task<MovementLine?> GetByIdAsync(int id, CancellationToken token = default)
            => _repo.GetByIdAsync(id, token);

        public Task<MovementLine?> UpdateAsync(MovementLine entity, CancellationToken token = default)
            => _repo.UpdateAsync(entity, token);
    }
}
