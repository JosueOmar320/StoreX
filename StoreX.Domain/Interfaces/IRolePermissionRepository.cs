using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Domain.Interfaces
{
    public interface IRolePermissionRepository
    {
        Task<IEnumerable<RolePermission>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<RolePermission?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<RolePermission> AddAsync(RolePermission rolePermission, CancellationToken cancellationToken = default);
        Task<RolePermission?> UpdateAsync(RolePermission rolePermission, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
