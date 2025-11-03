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

        public async Task<Permission> AddAsync(Permission entity, CancellationToken cancellationToken = default)
        {
            await _context.Permissions.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<Permission?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Permissions.FindAsync(id, cancellationToken);
        }

        public async Task<Permission?> UpdateAsync(Permission entity, CancellationToken cancellationToken = default)
        {
            var existing = await _context.Permissions.FindAsync(entity.PermissionId, cancellationToken);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Permissions.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.Permissions.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Permission>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Permissions.ToListAsync(cancellationToken);
        }
    }
}
