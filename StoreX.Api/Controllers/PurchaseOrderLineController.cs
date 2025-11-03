using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderLineController : ControllerBase
    {
        private readonly IPurchaseOrderLineService _purchaseOrderLineService;

        public PurchaseOrderLineController(IPurchaseOrderLineService purchaseOrderLineService)
        {
            _purchaseOrderLineService = purchaseOrderLineService;
        }

        [HttpGet(Name = "FetchAllPurchaseOrderLine")]
        [ProducesResponseType(typeof(IEnumerable<PurchaseOrderLine>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchAllPurchaseOrderLine(CancellationToken cancellationToken)
        {
            var data = await _purchaseOrderLineService.GetAllAsync(cancellationToken);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetPurchaseOrderLineById")]
        [ProducesResponseType(typeof(PurchaseOrderLine), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPurchaseOrderLineById(int id, CancellationToken cancellationToken)
        {
            var line = await _purchaseOrderLineService.GetByIdAsync(id, cancellationToken);
            if (line == null) return NotFound($"No se encontró un purchase order line con ID {id}");
            return Ok(line);
        }

        [HttpPost(Name = "CreatePurchaseOrderLine")]
        [ProducesResponseType(typeof(PurchaseOrderLine), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePurchaseOrderLine(PurchaseOrderLine line, CancellationToken cancellationToken)
        {
            var created = await _purchaseOrderLineService.AddAsync(line, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdatePurchaseOrderLine")]
        [ProducesResponseType(typeof(PurchaseOrderLine), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePurchaseOrderLine(int id, PurchaseOrderLine line, CancellationToken cancellationToken)
        {
            var updated = await _purchaseOrderLineService.UpdateAsync(line, cancellationToken);
            if (updated == null) return NotFound($"No se encontró un purchase order line con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeletePurchaseOrderLine")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePurchaseOrderLine(int id, CancellationToken cancellationToken)
        {
            var deleted = await _purchaseOrderLineService.DeleteAsync(id, cancellationToken);
            if (!deleted) return NotFound($"No se encontró un purchase order line con ID {id}");
            return Ok(true);
        }
    }
}
