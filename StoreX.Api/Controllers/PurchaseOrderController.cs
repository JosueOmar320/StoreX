using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        [HttpGet(Name = "FetchAllPurchaseOrder")]
        [ProducesResponseType(typeof(IEnumerable<PurchaseOrder>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchAllPurchaseOrder(CancellationToken cancellationToken)
        {
            var data = await _purchaseOrderService.GetAllAsync(cancellationToken);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetPurchaseOrderById")]
        [ProducesResponseType(typeof(PurchaseOrder), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPurchaseOrderById(int id, CancellationToken cancellationToken)
        {
            var purchaseOrder = await _purchaseOrderService.GetByIdAsync(id, cancellationToken);
            if (purchaseOrder == null) return NotFound($"No se encontró un purchase order con ID {id}");
            return Ok(purchaseOrder);
        }

        [HttpPost(Name = "CreatePurchaseOrder")]
        [ProducesResponseType(typeof(PurchaseOrder), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePurchaseOrder(PurchaseOrder purchaseOrder, CancellationToken cancellationToken)
        {
            var created = await _purchaseOrderService.AddAsync(purchaseOrder, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdatePurchaseOrder")]
        [ProducesResponseType(typeof(PurchaseOrder), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePurchaseOrder(int id, PurchaseOrder purchaseOrder, CancellationToken cancellationToken)
        {
            var updated = await _purchaseOrderService.UpdateAsync(purchaseOrder, cancellationToken);
            if (updated == null) return NotFound($"No se encontró un purchase order con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeletePurchaseOrder")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePurchaseOrder(int id, CancellationToken cancellationToken)
        {
            var deleted = await _purchaseOrderService.DeleteAsync(id, cancellationToken);
            if (!deleted) return NotFound($"No se encontró un purchase order con ID {id}");
            return Ok(true);
        }
    }
}
