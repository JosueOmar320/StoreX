using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreX.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public Task<Permission> AddAsync(Permission permission, CancellationToken cancellationToken = default)
            => _permissionRepository.AddAsync(permission, cancellationToken);

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
            => _permissionRepository.DeleteAsync(id, cancellationToken);

        public Task<IEnumerable<Permission>> GetAllAsync(CancellationToken cancellationToken = default)
            => _permissionRepository.GetAllAsync(cancellationToken);

        public Task<Permission?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _permissionRepository.GetByIdAsync(id, cancellationToken);

        public Task<Permission?> UpdateAsync(Permission permission, CancellationToken cancellationToken = default)
            => _permissionRepository.UpdateAsync(permission, cancellationToken);
    }
}
