using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Services
{
    public class PurchaseOrderLineService : IPurchaseOrderLineService
    {
        private readonly IPurchaseOrderLineRepository _purchaseOrderLineRepository;
        public PurchaseOrderLineService(IPurchaseOrderLineRepository purchaseOrderLineRepository)
        {
            _purchaseOrderLineRepository = purchaseOrderLineRepository;
        }
        public Task<PurchaseOrderLine> AddAsync(PurchaseOrderLine purchaseOrderLine, CancellationToken cancellationToken = default)
            => _purchaseOrderLineRepository.AddAsync(purchaseOrderLine, cancellationToken);

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
            => _purchaseOrderLineRepository.DeleteAsync(id, cancellationToken);

        public Task<IEnumerable<PurchaseOrderLine>> GetAllAsync(CancellationToken cancellationToken = default)
            => _purchaseOrderLineRepository.GetAllAsync(cancellationToken);

        public Task<PurchaseOrderLine?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _purchaseOrderLineRepository.GetByIdAsync(id, cancellationToken);

        public Task<PurchaseOrderLine?> UpdateAsync(PurchaseOrderLine purchaseOrderLine, CancellationToken cancellationToken = default)
            => _purchaseOrderLineRepository.UpdateAsync(purchaseOrderLine, cancellationToken);
    }
}
