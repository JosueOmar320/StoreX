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
    public class CashMovementRepository : ICashMovementRepository
    {
        private readonly AppDbContext _context;

        public CashMovementRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CashMovement> AddAsync(CashMovement entity)
        {
            await _context.CashMovements.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CashMovement> GetByIdAsync(int id)
        {
            return await _context.CashMovements.FindAsync(id);
        }

        public async Task<CashMovement> UpdateAsync(CashMovement entity)
        {
            var existing = await _context.CashMovements.FindAsync(entity.CashMovementId);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.CashMovements.FindAsync(id);
            if (entity == null)
                return false;

            _context.CashMovements.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CashMovement>> GetAllAsync()
        {
            return await _context.CashMovements.ToListAsync();
        }
    }
}
