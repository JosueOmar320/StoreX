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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> AddAsync(Payment entity, CancellationToken cancellationToken = default)
        {
            await _context.Payments.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<Payment?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Payments.FindAsync(id, cancellationToken);
        }

        public async Task<Payment?> UpdateAsync(Payment entity, CancellationToken cancellationToken = default)
        {
            var existing = await _context.Payments.FindAsync(entity.PaymentId, cancellationToken);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Payments.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.Payments.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Payments.ToListAsync(cancellationToken);
        }
    }

}
