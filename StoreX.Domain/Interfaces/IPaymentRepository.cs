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
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment> GetByIdAsync(int id);
        Task<Payment> AddAsync(Payment payment);
        Task<Payment> UpdateAsync(Payment payment);
        Task<bool> DeleteAsync(int id);
    }
}
