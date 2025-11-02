using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreX.Domain.Entities;

namespace StoreX.Domain.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Payment?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Payment> AddAsync(Payment payment, CancellationToken cancellationToken = default);
        Task<Payment?> UpdateAsync(Payment payment, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }

}
