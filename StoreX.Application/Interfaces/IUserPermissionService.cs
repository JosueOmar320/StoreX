using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Interfaces
{
    public interface IUserPermissionService
    {
        Task<IEnumerable<UserPermission>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<UserPermission?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<UserPermission> AddAsync(UserPermission userPermission, CancellationToken cancellationToken = default);
        Task<UserPermission?> UpdateAsync(UserPermission userPermission, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
