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

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await _context.Permissions.ToListAsync();
        }

        public Task<Permission> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Permission> UpdateAsync(Permission permission)
        {
            throw new NotImplementedException();
        }
    }

}
