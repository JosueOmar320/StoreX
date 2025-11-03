using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreX.Domain.Entities;

namespace StoreX.Domain.Interfaces
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Permission?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Permission> AddAsync(Permission permission, CancellationToken cancellationToken = default);
        Task<Permission?> UpdateAsync(Permission permission, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
