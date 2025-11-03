using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Customer> AddAsync(Customer customer, CancellationToken cancellationToken = default);
        Task<Customer?> UpdateAsync(Customer customer, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
