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
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _context;

        public PermissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Permission> AddAsync(Permission permission)
        {
            await _context.Permissions.AddAsync(permission);
            await _context.SaveChangesAsync();
            return permission;
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            var existingPermission = await _context.Permissions.FindAsync(id);
            if (existingPermission == null)
                return null;

            return existingPermission;
        }

        public async Task<Permission> UpdateAsync(Permission permission)
        {
            var existingPermission = await _context.Permissions.FindAsync(permission.PermissionId);
            if (existingPermission == null)
                return null;

            _context.Entry(existingPermission).CurrentValues.SetValues(permission);
            await _context.SaveChangesAsync();
            return existingPermission;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var permission = await _context.Permissions.FindAsync(id);
            if (permission == null)
                return false;

            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await _context.Permissions.ToListAsync();
        }
    }
}
