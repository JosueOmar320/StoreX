using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreX.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Task<Role> AddAsync(Role role, CancellationToken cancellationToken = default)
            => _roleRepository.AddAsync(role, cancellationToken);

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
            => _roleRepository.DeleteAsync(id, cancellationToken);

        public Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken = default)
            => _roleRepository.GetAllAsync(cancellationToken);

        public Task<Role?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _roleRepository.GetByIdAsync(id, cancellationToken);

        public Task<Role?> UpdateAsync(Role role, CancellationToken cancellationToken = default)
            => _roleRepository.UpdateAsync(role, cancellationToken);
    }
}
