using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet(Name = "FetchAllSupplier")]
        [ProducesResponseType(typeof(IEnumerable<Supplier>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> FetchAllSupplier(CancellationToken cancellationToken)
        {
            var data = await _supplierService.GetAllAsync(cancellationToken);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetSupplierById")]
        [ProducesResponseType(typeof(Supplier), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> GetSupplierById(int id, CancellationToken cancellationToken)
        {
            var supplier = await _supplierService.GetByIdAsync(id, cancellationToken);
            if (supplier == null)
                return NotFound($"No se encontró un proveedor con ID {id}");
            return Ok(supplier);
        }

        [HttpPost(Name = "CreateSupplier")]
        [ProducesResponseType(typeof(Supplier), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> CreateSupplier(Supplier supplier, CancellationToken cancellationToken)
        {
            var created = await _supplierService.AddAsync(supplier, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateSupplier")]
        [ProducesResponseType(typeof(Supplier), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> UpdateSupplier(int id, Supplier supplier, CancellationToken cancellationToken)
        {
            supplier.SupplierId = id;
            var updated = await _supplierService.UpdateAsync(supplier, cancellationToken);
            if (updated == null)
                return NotFound($"No se encontró un proveedor con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteSupplier")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> DeleteSupplier(int id, CancellationToken cancellationToken)
        {
            var deleted = await _supplierService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound($"No se encontró un proveedor con ID {id}");
            return Ok(true);
        }
    }
}
