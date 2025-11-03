using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Services
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly IUserPermissionRepository _userPermissionRepository;
        public UserPermissionService(IUserPermissionRepository userPermissionRepository)
        {
            _userPermissionRepository = userPermissionRepository;
        }
        public Task<UserPermission> AddAsync(UserPermission userPermission, CancellationToken cancellationToken = default)
            => _userPermissionRepository.AddAsync(userPermission, cancellationToken);

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
            => _userPermissionRepository.DeleteAsync(id, cancellationToken);

        public Task<IEnumerable<UserPermission>> GetAllAsync(CancellationToken cancellationToken = default)
            => _userPermissionRepository.GetAllAsync(cancellationToken);

        public Task<UserPermission?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _userPermissionRepository.GetByIdAsync(id, cancellationToken);

        public Task<UserPermission?> UpdateAsync(UserPermission userPermission, CancellationToken cancellationToken = default)
            => _userPermissionRepository.UpdateAsync(userPermission, cancellationToken);
    }
}
