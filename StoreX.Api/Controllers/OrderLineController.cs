using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderLineController : ControllerBase
    {
        private readonly IOrderLineService _orderLineService;

        public OrderLineController(IOrderLineService orderLineService)
        {
            _orderLineService = orderLineService;
        }

        [HttpGet(Name = "FetchAllOrderLine")]
        [ProducesResponseType(typeof(IEnumerable<OrderLine>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchAllOrderLine(CancellationToken cancellationToken)
        {
            var data = await _orderLineService.GetAllAsync(cancellationToken);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetOrderLineById")]
        [ProducesResponseType(typeof(OrderLine), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrderLineById(int id, CancellationToken cancellationToken)
        {
            var orderLine = await _orderLineService.GetByIdAsync(id, cancellationToken);
            if (orderLine == null) return NotFound($"No se encontró un order line con ID {id}");
            return Ok(orderLine);
        }

        [HttpPost(Name = "CreateOrderLine")]
        [ProducesResponseType(typeof(OrderLine), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrderLine(OrderLine orderLine, CancellationToken cancellationToken)
        {
            var created = await _orderLineService.AddAsync(orderLine, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateOrderLine")]
        [ProducesResponseType(typeof(OrderLine), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrderLine(int id, OrderLine orderLine, CancellationToken cancellationToken)
        {
            var updated = await _orderLineService.UpdateAsync(orderLine, cancellationToken);
            if (updated == null) return NotFound($"No se encontró un order line con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteOrderLine")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOrderLine(int id, CancellationToken cancellationToken)
        {
            var deleted = await _orderLineService.DeleteAsync(id, cancellationToken);
            if (!deleted) return NotFound($"No se encontró un order line con ID {id}");
            return Ok(true);
        }
    }
}
