using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Domain.Interfaces
{
    public interface IMovementRepository
    {
        Task<IEnumerable<Movement>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Movement?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Movement> AddAsync(Movement movement, CancellationToken cancellationToken = default);
        Task<Movement?> UpdateAsync(Movement movement, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }

}
