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
        Task<IEnumerable<CashMovement>> GetAllAsync();
        Task<CashMovement> GetByIdAsync(int id);
        Task<CashMovement> AddAsync(CashMovement cashMovement);
        Task<CashMovement> UpdateAsync(CashMovement cashMovement);
        Task<bool> DeleteAsync(int id);
    }

}
