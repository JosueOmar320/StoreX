using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreX.Domain.Entities;

namespace StoreX.Domain.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<UserRole>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<UserRole?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<UserRole> AddAsync(UserRole userRole, CancellationToken cancellationToken = default);
        Task<UserRole?> UpdateAsync(UserRole userRole, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
