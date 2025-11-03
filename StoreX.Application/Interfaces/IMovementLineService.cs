using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Interfaces
{
    public interface IMovementLineService
    {
        Task<IEnumerable<MovementLine>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<MovementLine?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<MovementLine> AddAsync(MovementLine movementLine, CancellationToken cancellationToken = default);
        Task<MovementLine?> UpdateAsync(MovementLine movementLine, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
