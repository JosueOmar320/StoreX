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

        public async Task<UserRole> AddAsync(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
            return userRole;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public Task<UserRole> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> UpdateAsync(UserRole userRole)
        {
            throw new NotImplementedException();
        }
    }
}
