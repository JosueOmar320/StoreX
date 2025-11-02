using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Domain.Interfaces
{
    public interface ICashSessionRepository
    {
        Task<IEnumerable<CashSession>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<CashSession?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<CashSession> AddAsync(CashSession cashSession, CancellationToken cancellationToken = default);
        Task<CashSession?> UpdateAsync(CashSession cashSession, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
