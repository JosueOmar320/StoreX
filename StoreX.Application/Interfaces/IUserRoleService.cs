using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Interfaces
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task<UserRole> GetByIdAsync(int id);
        Task<UserRole> AddAsync(UserRole userRole);
        Task<UserRole> UpdateAsync(UserRole userRole);
        Task<bool> DeleteAsync(int id);
    }
}
