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
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;

        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Supplier> AddAsync(Supplier entity, CancellationToken cancellationToken = default)
        {
            await _context.Suppliers.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<Supplier?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Suppliers.FindAsync(id, cancellationToken);
        }

        public async Task<Supplier?> UpdateAsync(Supplier entity, CancellationToken cancellationToken = default)
        {
            var existing = await _context.Suppliers.FindAsync(entity.SupplierId, cancellationToken);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Suppliers.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.Suppliers.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Suppliers.ToListAsync(cancellationToken);
        }
    }
}
