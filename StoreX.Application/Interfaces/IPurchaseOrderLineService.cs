using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Interfaces
{
    public interface IPurchaseOrderLineService
    {
        Task<IEnumerable<PurchaseOrderLine>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<PurchaseOrderLine?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<PurchaseOrderLine> AddAsync(PurchaseOrderLine purchaseOrderLine, CancellationToken cancellationToken = default);
        Task<PurchaseOrderLine?> UpdateAsync(PurchaseOrderLine purchaseOrderLine, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
