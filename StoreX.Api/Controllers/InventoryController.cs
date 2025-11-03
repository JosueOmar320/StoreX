using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet(Name = "FetchAllInventory")]
        [ProducesResponseType(typeof(IEnumerable<Inventory>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> FetchAllInventory(CancellationToken cancellationToken)
        {
            var data = await _inventoryService.GetAllAsync(cancellationToken);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetInventoryById")]
        [ProducesResponseType(typeof(Inventory), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> GetInventoryById(int id, CancellationToken cancellationToken)
        {
            var record = await _inventoryService.GetByIdAsync(id, cancellationToken);
            if (record == null)
                return NotFound($"No se encontró inventario con ID {id}");
            return Ok(record);
        }

        [HttpPost(Name = "CreateInventory")]
        [ProducesResponseType(typeof(Inventory), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> CreateInventory(Inventory inventory, CancellationToken cancellationToken)
        {
            var created = await _inventoryService.AddAsync(inventory, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateInventory")]
        [ProducesResponseType(typeof(Inventory), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> UpdateInventory(int id, Inventory inventory, CancellationToken cancellationToken)
        {
            var updated = await _inventoryService.UpdateAsync(inventory, cancellationToken);
            if (updated == null)
                return NotFound($"No se encontró inventario con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteInventory")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> DeleteInventory(int id, CancellationToken cancellationToken)
        {
            var deleted = await _inventoryService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound($"No se encontró inventario con ID {id}");
            return Ok(true);
        }
    }
}
