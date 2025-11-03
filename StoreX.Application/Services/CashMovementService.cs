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
    public class CashMovementService : ICashMovementService
    {
        private readonly ICashMovementRepository _repo;

        public CashMovementService(ICashMovementRepository repo)
        {
            _repo = repo;
        }

        public Task<CashMovement> AddAsync(CashMovement entity, CancellationToken token = default)
            => _repo.AddAsync(entity, token);

        public Task<bool> DeleteAsync(int id, CancellationToken token = default)
            => _repo.DeleteAsync(id, token);

        public Task<IEnumerable<CashMovement>> GetAllAsync(CancellationToken token = default)
            => _repo.GetAllAsync(token);

        public Task<CashMovement> GetByIdAsync(int id, CancellationToken token = default)
            => _repo.GetByIdAsync(id, token);

        public Task<CashMovement> UpdateAsync(CashMovement entity, CancellationToken token = default)
            => _repo.UpdateAsync(entity, token);
    }
}
