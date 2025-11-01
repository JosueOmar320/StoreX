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
        Task<IEnumerable<CashSession>> GetAllAsync();
        Task<CashSession> GetByIdAsync(int id);
        Task<CashSession> AddAsync(CashSession cashSession);
        Task<CashSession> UpdateAsync(CashSession cashSession);
        Task<bool> DeleteAsync(int id);
    }
}
