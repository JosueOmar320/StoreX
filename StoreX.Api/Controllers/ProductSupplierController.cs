using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSupplierController : ControllerBase
    {
        private readonly IProductSupplierService _productSupplierService;

        public ProductSupplierController(IProductSupplierService productSupplierService)
        {
            _productSupplierService = productSupplierService;
        }

        [HttpGet(Name = "FetchAllProductSuppliers")]
        [ProducesResponseType(typeof(IEnumerable<ProductSupplier>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> FetchAllProductSuppliers(CancellationToken cancellationToken)
        {
            var data = await _productSupplierService.GetAllAsync(cancellationToken);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetProductSupplierById")]
        [ProducesResponseType(typeof(ProductSupplier), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> GetProductSupplierById(int id, CancellationToken cancellationToken)
        {
            var record = await _productSupplierService.GetByIdAsync(id, cancellationToken);
            if (record == null)
                return NotFound($"No se encontró relación Producto-Proveedor con ID {id}");
            return Ok(record);
        }

        [HttpPost(Name = "CreateProductSupplier")]
        [ProducesResponseType(typeof(ProductSupplier), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> CreateProductSupplier(ProductSupplier productSupplier, CancellationToken cancellationToken)
        {
            var created = await _productSupplierService.AddAsync(productSupplier, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateProductSupplier")]
        [ProducesResponseType(typeof(ProductSupplier), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> UpdateProductSupplier(int id, ProductSupplier productSupplier, CancellationToken cancellationToken)
        {
            var updated = await _productSupplierService.UpdateAsync(productSupplier, cancellationToken);
            if (updated == null)
                return NotFound($"No se encontró relación Producto-Proveedor con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteProductSupplier")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> DeleteProductSupplier(int id, CancellationToken cancellationToken)
        {
            var deleted = await _productSupplierService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound($"No se encontró relación Producto-Proveedor con ID {id}");
            return Ok(true);
        }
    }
}
