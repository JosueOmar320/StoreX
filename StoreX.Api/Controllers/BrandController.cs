using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Common.Interfaces;
using StoreX.Domain.Entities;
using System.Threading;

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

        [HttpGet(Name = "FetchAllBrand")]
        [ProducesResponseType(typeof(IEnumerable<Brand>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> FetchAllBrand(CancellationToken cancellationToken)
        {
            //try
            //{
            //    //// Check if the request was cancelled
            //if (cancellationToken.IsCancellationRequested)
            //    return re;

            var data = await _brandService.GetAllAsync();


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

        [HttpPost(Name = "CreateBrand")]
        [ProducesResponseType(typeof(Brand), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> CreateBrand(Brand brand,CancellationToken cancellationToken)
        {
            //try
            //{
            //    //// Check if the request was cancelled
            //if (cancellationToken.IsCancellationRequested)
            //    return re;

            var data = await _brandService.AddAsync(brand);


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
