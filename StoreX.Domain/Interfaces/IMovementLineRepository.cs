using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Domain.Interfaces
{
    public interface IMovementLineRepository
    {
        Task<IEnumerable<MovementLine>> GetAllAsync();
        Task<MovementLine> GetByIdAsync(int id);
        Task<MovementLine> AddAsync(MovementLine movementLine);
        Task<MovementLine> UpdateAsync(MovementLine movementLine);
        Task<bool> DeleteAsync(int id);
    }

}
