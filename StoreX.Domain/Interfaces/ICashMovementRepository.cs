using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Domain.Interfaces
{
    public interface ICashMovementRepository
    {
        Task<IEnumerable<CashMovement>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<CashMovement?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<CashMovement> AddAsync(CashMovement cashMovement, CancellationToken cancellationToken = default);
        Task<CashMovement?> UpdateAsync(CashMovement cashMovement, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }

}
