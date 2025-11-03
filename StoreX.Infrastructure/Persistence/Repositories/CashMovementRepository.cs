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

        public async Task<CashMovement> AddAsync(CashMovement entity, CancellationToken cancellationToken = default)
        {
            await _context.CashMovements.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<CashMovement?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.CashMovements.FindAsync(id, cancellationToken);
        }

        public async Task<CashMovement?> UpdateAsync(CashMovement entity, CancellationToken cancellationToken = default)
        {
            var existing = await _context.CashMovements.FindAsync(entity.CashMovementId, cancellationToken);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.CashMovements.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.CashMovements.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<CashMovement>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.CashMovements.ToListAsync(cancellationToken);
        }
    }

}
