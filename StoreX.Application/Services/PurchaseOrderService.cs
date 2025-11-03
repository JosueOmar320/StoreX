using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreX.Application.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public Task<PurchaseOrder> AddAsync(PurchaseOrder purchaseOrder, CancellationToken cancellationToken = default)
            => _purchaseOrderRepository.AddAsync(purchaseOrder, cancellationToken);

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
            => _purchaseOrderRepository.DeleteAsync(id, cancellationToken);

        public Task<IEnumerable<PurchaseOrder>> GetAllAsync(CancellationToken cancellationToken = default)
            => _purchaseOrderRepository.GetAllAsync(cancellationToken);

        public Task<PurchaseOrder?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _purchaseOrderRepository.GetByIdAsync(id, cancellationToken);

        public Task<PurchaseOrder?> UpdateAsync(PurchaseOrder purchaseOrder, CancellationToken cancellationToken = default)
            => _purchaseOrderRepository.UpdateAsync(purchaseOrder, cancellationToken);
    }
}
