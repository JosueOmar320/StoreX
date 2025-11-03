using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreX.Application.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public Task<UserRole> AddAsync(UserRole userRole, CancellationToken cancellationToken = default)
            => _userRoleRepository.AddAsync(userRole, cancellationToken);

        public Task<bool> DeleteAsync(int userId, int roleId, CancellationToken cancellationToken = default)
            => _userRoleRepository.DeleteAsync(userId, roleId, cancellationToken);

        public Task<IEnumerable<UserRole>> GetAllAsync(CancellationToken cancellationToken = default)
            => _userRoleRepository.GetAllAsync(cancellationToken);

        public Task<UserRole?> GetByIdAsync(int userId, int roleId, CancellationToken cancellationToken = default)
            => _userRoleRepository.GetByIdAsync(userId, roleId, cancellationToken);

        public Task<UserRole?> UpdateAsync(UserRole userRole, CancellationToken cancellationToken = default)
            => _userRoleRepository.UpdateAsync(userRole, cancellationToken);
    }
}
