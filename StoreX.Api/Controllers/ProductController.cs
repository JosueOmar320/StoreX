using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet(Name = "FetchAllProduct")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> FetchAllProduct(CancellationToken cancellationToken)
        {
            var data = await _productService.GetAllAsync(cancellationToken);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        // GET: api/Product/{id}
        [HttpGet("{id:int}", Name = "GetProductById")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> GetProductById(int id, CancellationToken cancellationToken)
        {
            var product = await _productService.GetByIdAsync(id, cancellationToken);
            if (product == null)
                return NotFound($"No se encontró un producto con ID {id}");

            return Ok(product);
        }

        // POST: api/Product
        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> CreateProduct(Product product, CancellationToken cancellationToken)
        {

            var created = await _productService.AddAsync(product, cancellationToken);
            return Ok(created);
        }

        // PUT: api/Product/{id}
        [HttpPut("{id:int}", Name = "UpdateProduct")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> UpdateProduct(int id, Product product, CancellationToken cancellationToken)
        {
            var updated = await _productService.UpdateAsync(product, cancellationToken);
            if (updated == null)
                return NotFound($"No se encontró un producto con ID {id}");

            return Ok(updated);
        } 

        // DELETE: api/Product/{id}
        [HttpDelete("{id:int}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            var deleted = await _productService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound($"No se encontró un producto con ID {id}");

            return Ok(true);
        }
    }
}
