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
        Task<IEnumerable<UserPermission>> GetAllAsync();
        Task<UserPermission> GetByIdAsync(int id);
        Task<UserPermission> AddAsync(UserPermission userPermission);
        Task<UserPermission> UpdateAsync(UserPermission userPermission);
        Task<bool> DeleteAsync(int id);
    }
}
