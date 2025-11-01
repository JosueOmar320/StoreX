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
        Task<IEnumerable<PurchaseOrder>> GetAllAsync();
        Task<PurchaseOrder> GetByIdAsync(int id);
        Task<PurchaseOrder> AddAsync(PurchaseOrder purchaseOrder);
        Task<PurchaseOrder> UpdateAsync(PurchaseOrder purchaseOrder);
        Task<bool> DeleteAsync(int id);
    }
}
