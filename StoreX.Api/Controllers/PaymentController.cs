using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet(Name = "FetchAllPayment")]
        [ProducesResponseType(typeof(IEnumerable<Payment>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchAllPayment(CancellationToken cancellationToken)
        {
            var data = await _paymentService.GetAllAsync(cancellationToken);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetPaymentById")]
        [ProducesResponseType(typeof(Payment), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPaymentById(int id, CancellationToken cancellationToken)
        {
            var payment = await _paymentService.GetByIdAsync(id, cancellationToken);
            if (payment == null) return NotFound($"No se encontró un payment con ID {id}");
            return Ok(payment);
        }

        [HttpPost(Name = "CreatePayment")]
        [ProducesResponseType(typeof(Payment), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePayment(Payment payment, CancellationToken cancellationToken)
        {
            var created = await _paymentService.AddAsync(payment, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdatePayment")]
        [ProducesResponseType(typeof(Payment), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePayment(int id, Payment payment, CancellationToken cancellationToken)
        {
            var updated = await _paymentService.UpdateAsync(payment, cancellationToken);
            if (updated == null) return NotFound($"No se encontró un payment con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeletePayment")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePayment(int id, CancellationToken cancellationToken)
        {
            var deleted = await _paymentService.DeleteAsync(id, cancellationToken);
            if (!deleted) return NotFound($"No se encontró un payment con ID {id}");
            return Ok(true);
        }
    }
}
