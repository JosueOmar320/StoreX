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
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly AppDbContext _context;

        public UserRoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserRole> AddAsync(UserRole entity, CancellationToken cancellationToken = default)
        {
            await _context.UserRoles.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<UserRole?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.UserRoles.FindAsync(id, cancellationToken);
        }

        //public async Task<UserRole?> UpdateAsync(UserRole entity, CancellationToken cancellationToken = default)
        //{
        //    var existing = await _context.UserRoles.FindAsync(entity., cancellationToken);
        //    if (existing == null)
        //        return null;

        //    _context.Entry(existing).CurrentValues.SetValues(entity);
        //    await _context.SaveChangesAsync(cancellationToken);
        //    return existing;
        //}

        public Task<UserRole?> UpdateAsync(UserRole entity, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.UserRoles.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.UserRoles.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.UserRoles.ToListAsync(cancellationToken);
        }
    }
}
