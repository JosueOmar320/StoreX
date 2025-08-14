using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Common.Interfaces;
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

        [HttpGet(Name = "FetchAllProduct")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> FetchAllProduct(CancellationToken cancellationToken)
        {
            //try
            //{
            //    //// Check if the request was cancelled
            //if (cancellationToken.IsCancellationRequested)
            //    return re;

            var data = await _productService.GetAllAsync();


            //if (data == null)
            //    return NotFound();

            return Ok(data);
            //}
            //catch (OperationCanceledException)
            //{
            //    // The request was cancelled by the client
            //    //return StatusCode(StatusCodes.Status499ClientClosedRequest);
            //}
            //catch (Exception ex)
            //{
            //    UnifiedLogger.LogError(ex, "Failed Fetch TenantUser By Id");
            //    // Handle other exceptions
            //    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            //}
        }

        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType(typeof(Brand), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> CreateProduct(Product product, CancellationToken cancellationToken)
        {
            //try
            //{
            //    //// Check if the request was cancelled
            //if (cancellationToken.IsCancellationRequested)
            //    return re;

            var data = await _productService.AddAsync(product);


            //if (data == null)
            //    return NotFound();

            return Ok(data);
            //}
            //catch (OperationCanceledException)
            //{
            //    // The request was cancelled by the client
            //    //return StatusCode(StatusCodes.Status499ClientClosedRequest);
            //}
            //catch (Exception ex)
            //{
            //    UnifiedLogger.LogError(ex, "Failed Fetch TenantUser By Id");
            //    // Handle other exceptions
            //    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            //}
        }
    }
}
