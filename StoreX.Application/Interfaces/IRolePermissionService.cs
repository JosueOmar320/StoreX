using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Interfaces
{
    public interface IRolePermissionService
    {
        Task<IEnumerable<RolePermission>> GetAllAsync();
        Task<RolePermission> GetByIdAsync(int id);
        Task<RolePermission> AddAsync(RolePermission rolePermission);
        Task<RolePermission> UpdateAsync(RolePermission rolePermission);
        Task<bool> DeleteAsync(int id);
    }
}
