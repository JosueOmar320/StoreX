using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreX.Domain.Entities;

namespace StoreX.Domain.Interfaces
{
    public interface IOrderLineRepository
    {
        Task<IEnumerable<OrderLine>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<OrderLine?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<OrderLine> AddAsync(OrderLine orderLine, CancellationToken cancellationToken = default);
        Task<OrderLine?> UpdateAsync(OrderLine orderLine, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
