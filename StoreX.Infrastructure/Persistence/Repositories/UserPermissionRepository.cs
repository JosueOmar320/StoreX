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
    public class UserPermissionRepository : IUserPermissionRepository
    {
        private readonly AppDbContext _context;

        public UserPermissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserPermission> AddAsync(UserPermission userPermission)
        {
            await _context.UserPermissions.AddAsync(userPermission);
            await _context.SaveChangesAsync();
            return userPermission;
        }

        public async Task<UserPermission> GetByIdAsync(int userId, int permissionId)
        {
            var existing = await _context.UserPermissions
                .FirstOrDefaultAsync(up => up.UserId == userId && up.PermissionId == permissionId);

            if (existing == null)
                return null;

            return existing;
        }

        public async Task<UserPermission> UpdateAsync(UserPermission userPermission)
        {
            var existing = await _context.UserPermissions
                .FirstOrDefaultAsync(up => up.UserId == userPermission.UserId && up.PermissionId == userPermission.PermissionId);

            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(userPermission);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int userId, int permissionId)
        {
            var existing = await _context.UserPermissions
                .FirstOrDefaultAsync(up => up.UserId == userId && up.PermissionId == permissionId);

            if (existing == null)
                return false;

            _context.UserPermissions.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<UserPermission>> GetAllAsync()
        {
            return await _context.UserPermissions.ToListAsync();
        }
    }
}
