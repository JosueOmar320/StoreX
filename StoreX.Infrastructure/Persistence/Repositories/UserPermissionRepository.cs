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

        public async Task<UserPermission> AddAsync(UserPermission entity, CancellationToken cancellationToken = default)
        {
            await _context.UserPermissions.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<UserPermission?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.UserPermissions.FindAsync(id, cancellationToken);
        }

        public async Task<UserPermission?> UpdateAsync(UserPermission entity, CancellationToken cancellationToken = default)
        {
            var existing = await _context.UserPermissions.FindAsync(entity.UserPermissionId, cancellationToken);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.UserPermissions.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.UserPermissions.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<UserPermission>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.UserPermissions.ToListAsync(cancellationToken);
        }
    }

}
