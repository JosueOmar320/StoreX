using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<IEnumerable<PurchaseOrder>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<PurchaseOrder?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<PurchaseOrder> AddAsync(PurchaseOrder purchaseOrder, CancellationToken cancellationToken = default);
        Task<PurchaseOrder?> UpdateAsync(PurchaseOrder purchaseOrder, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
