using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet(Name = "FetchAllOrder")]
        [ProducesResponseType(typeof(IEnumerable<Order>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> FetchAllOrder(CancellationToken cancellationToken)
        {
            var data = await _orderService.GetAllAsync(cancellationToken);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        // GET: api/Order/{id}
        [HttpGet("{id:int}", Name = "GetOrderById")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> GetOrderById(int id, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetByIdAsync(id, cancellationToken);
            if (order == null)
                return NotFound($"No se encontró un order con ID {id}");

            return Ok(order);
        }

        // POST: api/Order
        [HttpPost(Name = "CreateOrder")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> CreateOrder(Order order, CancellationToken cancellationToken)
        {
            var created = await _orderService.AddAsync(order, cancellationToken);
            return Ok(created);
        }

        // PUT: api/Order/{id}
        [HttpPut("{id:int}", Name = "UpdateOrder")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> UpdateOrder(int id, Order order, CancellationToken cancellationToken)
        {
            var updated = await _orderService.UpdateAsync(order, cancellationToken);
            if (updated == null)
                return NotFound($"No se encontró un order con ID {id}");

            return Ok(updated);
        }

        // DELETE: api/Order/{id}
        [HttpDelete("{id:int}", Name = "DeleteOrder")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> DeleteOrder(int id, CancellationToken cancellationToken)
        {
            var deleted = await _orderService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound($"No se encontró un order con ID {id}");

            return Ok(true);
        }
    }
}
