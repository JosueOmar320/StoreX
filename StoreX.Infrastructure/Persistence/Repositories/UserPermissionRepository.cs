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

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserPermission>> GetAllAsync()
        {
            return await _context.UserPermissions.ToListAsync();
        }

        public Task<UserPermission> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserPermission> UpdateAsync(UserPermission userPermission)
        {
            throw new NotImplementedException();
        }
    }

}
