using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreX.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Task<Payment> AddAsync(Payment payment, CancellationToken cancellationToken = default)
            => _paymentRepository.AddAsync(payment, cancellationToken);

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
            => _paymentRepository.DeleteAsync(id, cancellationToken);

        public Task<IEnumerable<Payment>> GetAllAsync(CancellationToken cancellationToken = default)
            => _paymentRepository.GetAllAsync(cancellationToken);

        public Task<Payment?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _paymentRepository.GetByIdAsync(id, cancellationToken);

        public Task<Payment?> UpdateAsync(Payment payment, CancellationToken cancellationToken = default)
            => _paymentRepository.UpdateAsync(payment, cancellationToken);
    }
}
