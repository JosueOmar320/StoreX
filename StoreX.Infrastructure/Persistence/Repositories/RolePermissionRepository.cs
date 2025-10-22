using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
namespace StoreX.Infrastructure.Persistence.Repositories
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly AppDbContext _context;

        public RolePermissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RolePermission> AddAsync(RolePermission rolePermission)
        {
            await _context.RolePermissions.AddAsync(rolePermission);
            await _context.SaveChangesAsync();
            return rolePermission;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RolePermission>> GetAllAsync()
        {
            return await _context.RolePermissions.ToListAsync();
        }

        public Task<RolePermission> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RolePermission> UpdateAsync(RolePermission rolePermission)
        {
            throw new NotImplementedException();
        }
    }

}
