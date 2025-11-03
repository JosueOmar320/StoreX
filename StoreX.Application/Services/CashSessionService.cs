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
    public class CashSessionService : ICashSessionService
    {
        private readonly ICashSessionRepository _repo;

        public CashSessionService(ICashSessionRepository repo)
        {
            _repo = repo;
        }

        public Task<CashSession> AddAsync(CashSession entity, CancellationToken token = default)
            => _repo.AddAsync(entity, token);

        public Task<bool> DeleteAsync(int id, CancellationToken token = default)
            => _repo.DeleteAsync(id, token);

        public Task<IEnumerable<CashSession>> GetAllAsync(CancellationToken token = default)
            => _repo.GetAllAsync(token);

        public Task<CashSession> GetByIdAsync(int id, CancellationToken token = default)
            => _repo.GetByIdAsync(id, token);

        public Task<CashSession> UpdateAsync(CashSession entity, CancellationToken token = default)
            => _repo.UpdateAsync(entity, token);
    }
}
