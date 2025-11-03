using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreX.Application.Services
{
    public class OrderLineService : IOrderLineService
    {
        private readonly IOrderLineRepository _orderLineRepository;

        public OrderLineService(IOrderLineRepository orderLineRepository)
        {
            _orderLineRepository = orderLineRepository;
        }

        public Task<OrderLine> AddAsync(OrderLine orderLine, CancellationToken cancellationToken = default)
            => _orderLineRepository.AddAsync(orderLine, cancellationToken);

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
            => _orderLineRepository.DeleteAsync(id, cancellationToken);

        public Task<IEnumerable<OrderLine>> GetAllAsync(CancellationToken cancellationToken = default)
            => _orderLineRepository.GetAllAsync(cancellationToken);

        public Task<OrderLine?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _orderLineRepository.GetByIdAsync(id, cancellationToken);

        public Task<OrderLine?> UpdateAsync(OrderLine orderLine, CancellationToken cancellationToken = default)
            => _orderLineRepository.UpdateAsync(orderLine, cancellationToken);
    }
}
