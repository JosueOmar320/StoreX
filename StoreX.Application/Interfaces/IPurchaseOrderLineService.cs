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
        Task<IEnumerable<PurchaseOrderLine>> GetAllAsync();
        Task<PurchaseOrderLine> GetByIdAsync(int id);
        Task<PurchaseOrderLine> AddAsync(PurchaseOrderLine purchaseOrderLine);
        Task<PurchaseOrderLine> UpdateAsync(PurchaseOrderLine purchaseOrderLine);
        Task<bool> DeleteAsync(int id);
    }
}
