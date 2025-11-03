using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreX.Application.Services
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;

        public RolePermissionService(IRolePermissionRepository rolePermissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
        }

        public Task<RolePermission> AddAsync(RolePermission rolePermission, CancellationToken cancellationToken = default)
            => _rolePermissionRepository.AddAsync(rolePermission, cancellationToken);

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        //public Task<bool> DeleteAsync(int roleId, int permissionId, CancellationToken cancellationToken = default)
        //    => _rolePermissionRepository.DeleteAsync(roleId, permissionId, cancellationToken);

        public Task<IEnumerable<RolePermission>> GetAllAsync(CancellationToken cancellationToken = default)
            => _rolePermissionRepository.GetAllAsync(cancellationToken);

        public Task<RolePermission?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        //public Task<RolePermission?> GetByIdAsync(int roleId, int permissionId, CancellationToken cancellationToken = default)
        //    => _rolePermissionRepository.GetByIdAsync(roleId, permissionId, cancellationToken);

        public Task<RolePermission?> UpdateAsync(RolePermission rolePermission, CancellationToken cancellationToken = default)
            => _rolePermissionRepository.UpdateAsync(rolePermission, cancellationToken);
    }
}
