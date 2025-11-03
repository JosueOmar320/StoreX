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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Task<Order> AddAsync(Order order, CancellationToken cancellationToken = default)
            => _orderRepository.AddAsync(order, cancellationToken);

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
            => _orderRepository.DeleteAsync(id, cancellationToken);

        public Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
            => _orderRepository.GetAllAsync(cancellationToken);

        public Task<Order?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _orderRepository.GetByIdAsync(id, cancellationToken);

        public Task<Order?> UpdateAsync(Order order, CancellationToken cancellationToken = default)
            => _orderRepository.UpdateAsync(order, cancellationToken);
    }
}
