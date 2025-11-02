using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreX.Domain.Entities;
namespace StoreX.Domain.Interfaces
{
    public interface IUserPermissionRepository
    {
        Task<IEnumerable<UserPermission>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<UserPermission?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<UserPermission> AddAsync(UserPermission userPermission, CancellationToken cancellationToken = default);
        Task<UserPermission?> UpdateAsync(UserPermission userPermission, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }

}
