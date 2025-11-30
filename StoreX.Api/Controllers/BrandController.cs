using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET: api/Brand
        [HttpGet(Name = "FetchAllBrand")]
        [ProducesResponseType(typeof(IEnumerable<Brand>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> FetchAllBrand(CancellationToken cancellationToken)
        {
            var data = await _brandService.GetAllAsync(cancellationToken);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        // GET: api/Brand/{id}
        [HttpGet("{id:int}", Name = "GetBrandById")]
        [ProducesResponseType(typeof(Brand), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> GetBrandById(int id, CancellationToken cancellationToken)
        {
            var product = await _brandService.GetByIdAsync(id, cancellationToken);
            if (product == null)
                return NotFound($"No se encontró un brand con ID {id}");

            return Ok(product);
        }

        // POST: api/Brand
        [HttpPost(Name = "CreateBrand")]
        [ProducesResponseType(typeof(Brand), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> CreateBrand(Brand brand, CancellationToken cancellationToken)
        {

            var created = await _brandService.AddAsync(brand, cancellationToken);
            return Ok(created);
        }

        // PUT: api/Brand/{id}
        [HttpPut("{id:int}", Name = "UpdateBrand")]
        [ProducesResponseType(typeof(Brand), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> UpdateBrand(int id, Brand brand, CancellationToken cancellationToken)
        {
            brand.BrandId = id;
            var updated = await _brandService.UpdateAsync(brand, cancellationToken);
            if (updated == null)
                return NotFound($"No se encontró un brand con ID {id}");

            return Ok(updated);
        }

        // DELETE: api/Brand/{id}
        [HttpDelete("{id:int}", Name = "DeleteBrand")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> DeleteBrand(int id, CancellationToken cancellationToken)
        {
            var deleted = await _brandService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound($"No se encontró un brand con ID {id}");

            return Ok(true);
        }
    }
}
