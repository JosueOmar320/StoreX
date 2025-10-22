using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreX.Domain.Entities;

namespace StoreX.Domain.Interfaces
{
    public interface IPurchaseOrderLineRepository
    {
        Task<IEnumerable<PurchaseOrderLine>> GetAllAsync();
        Task<PurchaseOrderLine> GetByIdAsync(int id);
        Task<PurchaseOrderLine> AddAsync(PurchaseOrderLine purchaseOrderLine);
        Task<PurchaseOrderLine> UpdateAsync(PurchaseOrderLine purchaseOrderLine);
        Task<bool> DeleteAsync(int id);
    }
}
