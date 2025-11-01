using Microsoft.EntityFrameworkCore;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Infrastructure.Persistence.Repositories
{
    public class CashSessionRepository : ICashSessionRepository
    {
        private readonly AppDbContext _context;

        public CashSessionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CashSession> AddAsync(CashSession entity)
        {
            await _context.CashSessions.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CashSession> GetByIdAsync(int id)
        {
            return await _context.CashSessions.FindAsync(id);
        }

        public async Task<CashSession> UpdateAsync(CashSession entity)
        {
            var existing = await _context.CashSessions.FindAsync(entity.CashSessionId);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.CashSessions.FindAsync(id);
            if (entity == null)
                return false;

            _context.CashSessions.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CashSession>> GetAllAsync()
        {
            return await _context.CashSessions.ToListAsync();
        }
    }
}
