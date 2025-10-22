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
        Task<IEnumerable<UserPermission>> GetAllAsync();
        Task<UserPermission> GetByIdAsync(int id);
        Task<UserPermission> AddAsync(UserPermission userPermission);
        Task<UserPermission> UpdateAsync(UserPermission userPermission);
        Task<bool> DeleteAsync(int id);
    }
}
