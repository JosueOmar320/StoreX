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

        public async Task<CashSession> AddAsync(CashSession entity, CancellationToken cancellationToken = default)
        {
            await _context.CashSessions.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<CashSession?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.CashSessions.FindAsync(id, cancellationToken);
        }

        public async Task<CashSession?> UpdateAsync(CashSession entity, CancellationToken cancellationToken = default)
        {
            var existing = await _context.CashSessions.FindAsync(entity.CashSessionId, cancellationToken);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.CashSessions.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.CashSessions.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<CashSession>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.CashSessions.ToListAsync(cancellationToken);
        }
    }
}
