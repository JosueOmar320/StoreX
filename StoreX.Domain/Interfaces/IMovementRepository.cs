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
        Task<IEnumerable<Movement>> GetAllAsync();
        Task<Movement> GetByIdAsync(int id);
        Task<Movement> AddAsync(Movement movement);
        Task<Movement> UpdateAsync(Movement movement);
        Task<bool> DeleteAsync(int id);
    }
}
