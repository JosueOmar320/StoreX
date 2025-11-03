using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPriceController : ControllerBase
    {
        private readonly IProductPriceService _productPriceService;

        public ProductPriceController(IProductPriceService productPriceService)
        {
            _productPriceService = productPriceService;
        }

        [HttpGet(Name = "FetchAllProductPrice")]
        [ProducesResponseType(typeof(IEnumerable<ProductPrice>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchAllProductPrice(CancellationToken cancellationToken)
        {
            var data = await _productPriceService.GetAllAsync(cancellationToken);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetProductPriceById")]
        [ProducesResponseType(typeof(ProductPrice), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductPriceById(int id, CancellationToken cancellationToken)
        {
            var productPrice = await _productPriceService.GetByIdAsync(id, cancellationToken);
            if (productPrice == null) return NotFound($"No se encontró un product price con ID {id}");
            return Ok(productPrice);
        }

        [HttpPost(Name = "CreateProductPrice")]
        [ProducesResponseType(typeof(ProductPrice), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProductPrice(ProductPrice productPrice, CancellationToken cancellationToken)
        {
            var created = await _productPriceService.AddAsync(productPrice, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateProductPrice")]
        [ProducesResponseType(typeof(ProductPrice), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProductPrice(int id, ProductPrice productPrice, CancellationToken cancellationToken)
        {
            var updated = await _productPriceService.UpdateAsync(productPrice, cancellationToken);
            if (updated == null) return NotFound($"No se encontró un product price con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteProductPrice")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProductPrice(int id, CancellationToken cancellationToken)
        {
            var deleted = await _productPriceService.DeleteAsync(id, cancellationToken);
            if (!deleted) return NotFound($"No se encontró un product price con ID {id}");
            return Ok(true);
        }
    }
}
