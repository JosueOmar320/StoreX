using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet(Name = "FetchAllProductCategory")]
        [ProducesResponseType(typeof(IEnumerable<ProductCategory>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> FetchAllProductCategory(CancellationToken cancellationToken)
        {
            var data = await _productCategoryService.GetAllAsync(cancellationToken);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetProductCategoryById")]
        [ProducesResponseType(typeof(ProductCategory), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> GetProductCategoryById(int id, CancellationToken cancellationToken)
        {
            var entity = await _productCategoryService.GetByIdAsync(id, cancellationToken);
            if (entity == null)
                return NotFound($"No se encontró un ProductCategory con ID {id}");

            return Ok(entity);
        }

        [HttpPost(Name = "CreateProductCategory")]
        [ProducesResponseType(typeof(ProductCategory), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> CreateProductCategory(ProductCategory productCategory, CancellationToken cancellationToken)
        {
            var created = await _productCategoryService.AddAsync(productCategory, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateProductCategory")]
        [ProducesResponseType(typeof(ProductCategory), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> UpdateProductCategory(int id, ProductCategory productCategory, CancellationToken cancellationToken)
        {
            var updated = await _productCategoryService.UpdateAsync(productCategory, cancellationToken);
            if (updated == null)
                return NotFound($"No se encontró un ProductCategory con ID {id}");

            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteProductCategory")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> DeleteProductCategory(int id, CancellationToken cancellationToken)
        {
            var deleted = await _productCategoryService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound($"No se encontró un ProductCategory con ID {id}");

            return Ok(true);
        }
    }
}
