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
        Task<IEnumerable<OrderLine>> GetAllAsync();
        Task<OrderLine> GetByIdAsync(int id);
        Task<OrderLine> AddAsync(OrderLine orderLine);
        Task<OrderLine> UpdateAsync(OrderLine orderLine);
        Task<bool> DeleteAsync(int id);
    }
}
