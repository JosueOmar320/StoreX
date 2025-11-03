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

        public async Task<RolePermission> AddAsync(RolePermission entity, CancellationToken cancellationToken = default)
        {
            await _context.RolePermissions.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<RolePermission?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.RolePermissions.FindAsync(id, cancellationToken);
        }

        //public async Task<RolePermission?> UpdateAsync(RolePermission entity, CancellationToken cancellationToken = default)
        //{
        //    var existing = await _context.RolePermissions.FindAsync(entity.RolePermissionId, cancellationToken);
        //    if (existing == null)
        //        return null;

        //    _context.Entry(existing).CurrentValues.SetValues(entity);
        //    await _context.SaveChangesAsync(cancellationToken);
        //    return existing;
        //}

        public Task<RolePermission?> UpdateAsync(RolePermission entity, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.RolePermissions.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.RolePermissions.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<RolePermission>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.RolePermissions.ToListAsync(cancellationToken);
        }
    }
}
