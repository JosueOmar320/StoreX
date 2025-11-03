using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Role?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Role> AddAsync(Role role, CancellationToken cancellationToken = default);
        Task<Role?> UpdateAsync(Role role, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
